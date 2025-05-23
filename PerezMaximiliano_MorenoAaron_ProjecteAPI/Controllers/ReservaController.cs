using Data;
using Entitats.AuthClasses;
using Entitats.HorariClasses;
using Entitats.ReservaClasses;
using Entitats.TaulaClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Entitats.RestaurantClasses;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly DBContext _context;
        public ReservaController(DBContext context)
        {
            _context = context;
        }

        [HttpGet("GetHorariRestaurant")]
        public async Task<IActionResult> GetHorariRestaurant([FromQuery] int restaurantid)
        {
            var horariRestaurant = await _context.Horaris.Where(h => h.restaurantid == restaurantid).OrderBy(x=>x.hora_inici).ToListAsync();

            return Ok(horariRestaurant);
        }

        [HttpGet("GetNumeroComensals")]
        public async Task<IActionResult> GetNumeroComensals([FromQuery] int restaurantid)
        {
            // Obtenim les capacitats de les taules del restaurant (amb distinct per evitar duplicats en cas de que hi hagi més d'una taula amb la mateixa capacitat).
            var numComensals = await _context.Taules.Where(t => t.restaurantId == restaurantid).Select(t => t.numComensals).Distinct().OrderBy(c => c).ToListAsync();

            return Ok(numComensals);
        }

        [HttpGet("GetFrangesHoraries")]
        public async Task<IActionResult> GetFrangesHoraries(int dia, int restaurantid)
        {
            try
            {
                // Recoge las franjas horarias del restaurante para el día específico
                var horaris = await _context.Horaris.Where(h => h.restaurantid == restaurantid && h.dia == dia).OrderBy(x=>x.hora_inici).ToListAsync();

                return Ok(horaris);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al carregar els horaris. " + ex.Message, ex);
            }
        }

        [HttpPost("GetHoresDisponibles")]
        public async Task<IActionResult> GetHoresDisponibles(DateTime data, Horari franjaSeleccionada, int numComensals, int duradaSeleccionada, int restaurantid, int? idReserva)
        {
            var taulesDisponibles = await _context.Taules.Where(x => x.restaurantId == restaurantid && x.numComensals == numComensals).OrderBy(x => x.numComensals).ToListAsync();
            var idTaulesRestaurant = await _context.Taules.Where(x => x.restaurantId == restaurantid).Select(x => x.id).ToListAsync();

            if (idTaulesRestaurant.Count == 0) return NotFound();

            List<Reserva> reservesDelDia = new List<Reserva>();

            // Si estamos añadiendo será nulo y por tanto cogeremos todas las reservas disponibles 
            if (idReserva == null)
            {
                reservesDelDia = await _context.Reservas.Where(x => idTaulesRestaurant.Contains(x.taulaid)).Where(x => x.datareserva.Date == data.Date)
               .Where(x => x.estatid == (int)EstatReserva.EnProces).OrderBy(x => x.datareserva).ToListAsync();
            }
            else // Si estamos modificando tendrá una reserva almacenada y la excluiremos, para así poder escoger las horas sin contar que esa mesa para esa hora esté ya reservada
            {
                reservesDelDia = await _context.Reservas.Where(x => idTaulesRestaurant.Contains(x.taulaid)).Where(x => x.datareserva.Date == data.Date)
                .Where(x => x.estatid == (int)EstatReserva.EnProces).Where(x => x.id != idReserva).OrderBy(x => x.datareserva).ToListAsync();
            }
           
            List<TimeSpan> horesDisponibles = new List<TimeSpan>();


            // Vamos probando horas dentro de la franja horaria, desde el inicio hasta el final, moviéndonos en intervalos de 15 minutos.
            // Cada 'hora' representa un posible inicio para una nueva reserva.

            for (TimeSpan hora = franjaSeleccionada.hora_inici;
                 hora.Add(TimeSpan.FromMinutes(duradaSeleccionada)) <= franjaSeleccionada.hora_final; // La nueva reserva debe terminar antes o justo al final de la franja
                 hora = hora.Add(TimeSpan.FromMinutes(15))) // Avanzamos 15 minutos para probar la siguiente hora posible
            {

                // Comprobar y descartar las horas que ya hayan pasado en el día de hoy para que no se muestren como reservables
                if (data.Date == DateTime.Now.Date)
                {
                    DateTime horaCompleta = data.Date + hora;

                    if (horaCompleta < DateTime.Now) continue; // Descarta esta hora porque ya ha pasado
                }

                int taulesOcupades = 0;

                // Revisamos todas las reservas existentes para ver si alguna se solapa con esta hora
                foreach (var reserva in reservesDelDia)
                {
                    if (reserva.hora.HasValue)
                    {
                        // Hora de inicio y fin de la reserva ya existente
                        TimeSpan horaIniciReserva = reserva.hora.Value;
                        TimeSpan horaFiReserva = horaIniciReserva.Add(TimeSpan.FromMinutes(reserva.durada)); // Sumamos la duracion para saber cuando acabará la reserva

                        // Hora de fin si la nueva reserva empieza en 'hora'
                        TimeSpan horaNovaFi = hora.Add(TimeSpan.FromMinutes(duradaSeleccionada));  // Sumamos la duracion para saber cuando acabará la reserva

                        // Verificamos si la nueva reserva y la existente se solapan en el tiempo
                        bool solapen = hora < horaFiReserva && horaNovaFi > horaIniciReserva;

                        if (solapen) taulesOcupades++; // En caso de solaparse, contamos esta mesa como ocupada
                    }
                }

                // Si hay mesas libres para esta hora, la añadimos a la lista de horas disponibles
                if (taulesOcupades < taulesDisponibles.Count)
                {
                    horesDisponibles.Add(hora);
                }
            }

            return Ok(horesDisponibles);
        }

        [HttpGet("GetReserves")]
        public async Task<IActionResult> GetReserves([FromQuery] int usuariId)
        {

            var reservesUsuari = await _context.Reservas.Where(t => t.usuariId == usuariId).ToListAsync();

            return Ok(reservesUsuari);
        }


        [HttpPost("AddReserva")]
        public async Task<IActionResult> AddReserva([FromBody] Reserva novaReserva)
        {
            var taulaDisponible = GetTaulaDisponible(novaReserva.numcomensals, novaReserva.datareserva, novaReserva.hora, novaReserva.durada, novaReserva.restaurantid, null);

            // Si no hi ha cap taula disponible no reservem
            if (taulaDisponible == null) return BadRequest("No hi ha cap taula disponible per a aquest horari.");

            novaReserva.taulaid = taulaDisponible.id;
            novaReserva.estatid = (int)EstatReserva.EnProces; 

            _context.Reservas.Add(novaReserva);
            await _context.SaveChangesAsync();

            var restaurante = await _context.Restaurants.FindAsync(novaReserva.restaurantid);

            var usuari = await _context.Usuaris.FindAsync(novaReserva.usuariId);

            if (usuari != null && EsCorreoValido(usuari.correu) && EsCorreoValido(restaurante.correu)) EnviarCorreuConfirmacio(usuari, restaurante, novaReserva);

            return Ok("Reserva afegida amb èxit.");
        }

        [HttpPut("UpdateReserva")]
        public async Task<IActionResult> UpdateReserva([FromBody] Reserva updReserva)
        {
            try
            {
                if (updReserva == null) return BadRequest();

                var reservaExistente = await _context.Reservas.FindAsync(updReserva.id);

                if (reservaExistente == null) return NotFound();

                var taulaDisponible = GetTaulaDisponible(updReserva.numcomensals, updReserva.datareserva, updReserva.hora, updReserva.durada, updReserva.restaurantid, updReserva.id);

                if (taulaDisponible == null) return NotFound();

                reservaExistente.datareserva = updReserva.datareserva;
                reservaExistente.numcomensals = updReserva.numcomensals;
                reservaExistente.taulaid = taulaDisponible.id;
                reservaExistente.durada = updReserva.durada;
                reservaExistente.hora = updReserva.hora;

                _context.SaveChanges();

                return Ok("Reserva modificada amb èxit.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualitzar la reserva. " + ex.Message, ex);
            }
        }

        [HttpPut("CancelarReserva")]
        public async Task<IActionResult> CancelarReserva(int reservaid)
        {
            var reserva = await _context.Reservas.FindAsync(reservaid);

            if (reserva == null) return NotFound("Reserva no trobada.");

            reserva.estatid = (int)EstatReserva.Cancelada;

            await _context.SaveChangesAsync();

            return Ok("Reserva cancel.lada amb èxit.");
        }

        #region Helpers

        private Taula GetTaulaDisponible(int? numComensals, DateTime data, TimeSpan? novaHora, int novaDurada, int restaurantid, int? reservaIdAExcloure)
        {
            // Coger las mesas del rest por numero de comensales
            var taules = _context.Taules.Where(t => t.numComensals == numComensals && t.restaurantId == restaurantid).ToList();

            // Coger las reservas del dia pendientes
            List<Reserva> reservesDelDia;

            // Coger las reservas del dia pendientes
            if (reservaIdAExcloure.HasValue)
            {
                // Excluir la reserva a modificar para así poder seleccionar su hora sin que cuente como seleccionada
                reservesDelDia = _context.Reservas.Where(r =>
                        r.datareserva.Date == data.Date &&
                        r.estatid == (int)EstatReserva.EnProces &&
                        r.id != reservaIdAExcloure.Value)
                    .ToList();
            }
            else // Es una reserva nueva, se cargan todas las reservas en proceso del día
            {
                reservesDelDia = _context.Reservas.Where(r =>
                        r.datareserva.Date == data.Date &&
                        r.estatid == (int)EstatReserva.EnProces)
                    .ToList();
            }

            foreach (var taula in taules)
            {
                // Comprobar si hay alguna mesa libre para esa hora
                bool solapada = reservesDelDia.Any(r => r.taulaid == taula.id && SolapaAmbReservaExistente(novaHora, novaDurada, r.hora, r.durada));

                // Devuelve la primera mesa disponible que no esté ocupada en el rango de horas
                if (!solapada)
                {
                    return taula;
                }
            }

            return null;
        }

        private bool SolapaAmbReservaExistente(TimeSpan? novaHora, int novaDuracio, TimeSpan? horaExistente, int duracioExistente)
        {
            if (!novaHora.HasValue || !horaExistente.HasValue) return false;

            TimeSpan fiNova = novaHora.Value.Add(TimeSpan.FromMinutes(novaDuracio)); // Calcular la hora de fin de la reserva nueva
            TimeSpan fiExistente = horaExistente.Value.Add(TimeSpan.FromMinutes(duracioExistente)); // Calcular la hora de fin de la reserva existente 

            // Comprobar si la nueva reserva empieza antes de que termine la reserva existente, y si la reserva existente empieza antes de que termine la nueva reserva

            if (novaHora.Value < fiExistente && horaExistente.Value < fiNova)
            {
                return true; // Si ambas coinciden (solapadas)
            }
            else
            {
                return false;
            }
        }

        private bool EsCorreoValido(string correo)
        {
            try
            {
                // Comprobar si el formato del correo es válido para enviar o recibir el mail
                var mail = new MailAddress(correo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void EnviarCorreuConfirmacio(Usuari usuari, Restaurant restaurant, Reserva reserva)
        {
            var fromAddress = new MailAddress(restaurant.correu, restaurant.nomRestaurant);
            var toAddress = new MailAddress(usuari.correu, usuari.nom);

            const string subject = "Confirmació de la teva reserva";

            // Logo
            byte[] logoBytes = restaurant.logo;
            MemoryStream logoStream = new MemoryStream(logoBytes);

            LinkedResource logo = new LinkedResource(logoStream, "image/png")
            {
                ContentId = "logoCid",
                TransferEncoding = System.Net.Mime.TransferEncoding.Base64
            };

            // Cuerpo del mensaje con html para darle mejor estética
            string htmlBody = $@"
            <html>
            <body style='font-family: Arial, sans-serif; color: #000000; background-color: #FFFFFF; margin:0; padding:20px;'>
                <div style='text-align: center; max-width: 600px; margin: auto; background-color: #FFFFFF; padding: 20px; border-radius: 8px;'>
                    <img src='cid:logoCid' alt='Logo del restaurant' width='120' style='margin-bottom: 20px;'/>
                    <h2 style='color: #FFB997; margin-bottom: 10px;'>Confirmació de Reserva</h2>
                    <p style='font-size: 16px; color: #000000;'>Hola <strong>{usuari.nom} {usuari.cognoms}</strong>,</p>
                    <p style='font-size: 16px; color: #000000;'>La teva reserva ha estat confirmada:</p>
                    <ul style='display: inline-block; text-align: left; font-size: 16px; color: #000000; padding-left: 20px; margin-bottom: 20px;'>
                        <li><strong>Data:</strong> {reserva.datareserva:dd/MM/yyyy}</li>
                        <li><strong>Hora:</strong> {reserva.hora?.ToString(@"hh\:mm")}</li>
                        <li><strong>Comensals:</strong> {reserva.numcomensals}</li>
                    </ul>
                    <p style='font-size: 16px; color: #000000;'>Gràcies per confiar en nosaltres.</p>
                    <p style='font-weight: bold; color: #000000; font-size: 14px;'>Restaurant {restaurant.nomRestaurant}</p>
                </div>
            </body>
            </html>";


            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");
            htmlView.LinkedResources.Add(logo);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                // Credenciales generadas en gmail
                Credentials = new NetworkCredential("aaron_morenobarradas@iescarlesvallbona.cat", "ypsv xpzw mssg kkeq")
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                IsBodyHtml = true
            })
            {
                message.AlternateViews.Add(htmlView);
                smtp.Send(message);
            }
            #endregion

        }
    }
}
