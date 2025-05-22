using Data;
using Entitats.HorariClasses;
using Entitats.ReservaClasses;
using Entitats.TaulaClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var horariRestaurant = await _context.Horaris.Where(h => h.restaurantid == restaurantid).ToListAsync();

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
                var horaris = await _context.Horaris.Where(h => h.restaurantid == restaurantid && h.dia == dia).ToListAsync();

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
            // Mesas disponibles para el número de comensales y el restaurante
            var taules = await _context.Taules.Where(t => t.numComensals == novaReserva.numcomensals && t.restaurantId == novaReserva.restaurantid).ToListAsync();

            var reservesDelDia = await _context.Reservas.Where(r => r.datareserva.Date == novaReserva.datareserva.Date && r.estatid == (int)EstatReserva.EnProces).ToListAsync();

            Taula taulaDisponible = null;

            foreach (var taula in taules)
            {
                // Reservas de cada mesa con el número de comensales correspondiente
                var reservesTaula = reservesDelDia.Where(r => r.taulaid == taula.id);

                bool solapada = false;

                foreach (var r in reservesTaula)
                {
                    var horaExistente = r.hora;
                    var duracioExistente = r.durada;

                    var fiNova = novaReserva.hora.Value.Add(TimeSpan.FromMinutes(novaReserva.durada)); // Calcular la hora de fin de la reserva nueva
                    var fiExistente = horaExistente.Value.Add(TimeSpan.FromMinutes(duracioExistente)); // Calcular la hora de fin de la reserva existente

                    // Comprobar si la nueva reserva empieza antes de que termine la reserva existente, y si la reserva existente empieza antes de que termine la nueva reserva
                    if (novaReserva.hora < fiExistente && horaExistente < fiNova)
                    {
                        solapada = true;
                        break;
                    }
                }

                // Si no está solapada guardamos la mesa
                if (!solapada)
                {
                    taulaDisponible = taula;
                    break;
                }
            }

            // Si no hi ha cap taula disponible no reservem
            if (taulaDisponible == null) return BadRequest("No hi ha cap taula disponible per a aquest horari.");

            novaReserva.taulaid = taulaDisponible.id;
            novaReserva.estatid = (int)EstatReserva.EnProces; 

            _context.Reservas.Add(novaReserva);
            await _context.SaveChangesAsync();

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

                // Buscar mesas disponibles
                var taules = await _context.Taules.Where(t => t.numComensals == updReserva.numcomensals && t.restaurantId == updReserva.restaurantid).ToListAsync();
                var reservesDelDia = await _context.Reservas.Where(r => r.datareserva.Date == updReserva.datareserva.Date && (r.estatid == (int)EstatReserva.EnProces)).ToListAsync();

                Taula taulaDisponible = null;

                foreach (var taula in taules)
                {
                    var solapada = false;

                    TimeSpan fiNova = updReserva.hora.Value.Add(TimeSpan.FromMinutes(updReserva.durada)); // Calcular la hora de fin de la reserva nueva
                    TimeSpan fiExistente = reservaExistente.hora.Value.Add(TimeSpan.FromMinutes(reservaExistente.durada)); // Calcular la hora de fin de la reserva existente 

                    // Comprobar si la nueva reserva empieza antes de que termine la reserva existente, y si la reserva existente empieza antes de que termine la nueva reserva

                    if (updReserva.hora.Value < fiExistente && reservaExistente.hora.Value < fiNova)
                    {
                        solapada = true; // Si ambas coinciden (solapadas)
                    }

                    // Comprobar si hay alguna mesa libre para esa hora
                    bool ocupada = reservesDelDia.Any(r => r.taulaid == taula.id && solapada);

                    // Devuelve la primera mesa disponible que no esté ocupada en el rango de horas
                    if (!ocupada)
                    {
                        taulaDisponible = taula;
                    }
                }

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
    }
}
