using Data;
using Entitats.AuthClasses;
using Entitats.ContacteClasses;
using Entitats.HorariClasses;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Entitats.TaulaClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;

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

            var numComensals = await _context.Taules
                           .Where(t => t.restaurantId == restaurantid)
                           .Select(t => t.numComensals)
                           .Distinct()
                           .OrderBy(c => c)
                           .ToListAsync();

            return Ok(numComensals);
        }

        [HttpGet("GetFrangesHoraries")]
        public async Task<IActionResult> GetFrangesHoraries(int dia, int restaurantid)
        {
            try
            {
                // Recoger las franjas horarias del restaurante para el día específico
                var horaris = await _context.Horaris
                    .Where(h => h.restaurantid == restaurantid && h.dia == dia)
                    .ToListAsync();

                return Ok(horaris);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los horarios. " + ex.Message, ex);
            }
        }

        [HttpPost("GetHoresDisponibles")]
        public async Task<IActionResult> GetHoresDisponibles(DateTime data, Horari franjaSeleccionada, int numComensals, int duradaSeleccionada, int restaurantid)
        {
            var taulesDisponibles = await _context.Taules.Where(x => x.restaurantId == restaurantid && x.numComensals == numComensals).OrderBy(x => x.numComensals).ToListAsync();

            var idTaulesRestaurant = _context.Taules
          .Where(x => x.restaurantId == restaurantid)
          .Select(x => x.id)
          .ToList();

            if (idTaulesRestaurant.Count == 0)
                return NotFound();

            // Obtener las reservas para ese día específico
            var reservasDelDia = await _context.Reservas
                .Where(x => idTaulesRestaurant.Contains(x.taulaid))
                .Where(x => x.datareserva.Date == data.Date)
                .Where(x => x.estatid == (int)EstatReserva.EnProces)
                .OrderBy(x => x.datareserva)
                .ToListAsync();

            List<TimeSpan> horesDisponibles = new List<TimeSpan>();

            for (TimeSpan hora = franjaSeleccionada.hora_inici;
                    hora.Add(TimeSpan.FromMinutes(duradaSeleccionada)) <= franjaSeleccionada.hora_final;
                    hora = hora.Add(TimeSpan.FromMinutes(15)))
            {
                int taulesOcupades = 0;

                foreach (var reserva in reservasDelDia)
                {
                    if (reserva.hora.HasValue)
                    {
                        TimeSpan horaIniciReserva = reserva.hora.Value;
                        TimeSpan horaFiReserva = horaIniciReserva.Add(TimeSpan.FromMinutes(reserva.durada));

                        TimeSpan horaNovaFi = hora.Add(TimeSpan.FromMinutes(duradaSeleccionada));

                        // Verificar solapamiento
                        bool solapen = hora < horaFiReserva && horaNovaFi > horaIniciReserva;

                        if (solapen)
                            taulesOcupades++;
                    }
                }

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

            var reservesUsuari = await _context.Reservas
                           .Where(t => t.usuariId == usuariId)
                           .ToListAsync();

            return Ok(reservesUsuari);
        }


        [HttpPost("AddReserva")]
        public async Task<IActionResult> AddReserva([FromBody] Reserva novaReserva)
        {
            var taules = _context.Taules
                .Where(t => t.numComensals == novaReserva.numcomensals && t.restaurantId == novaReserva.restaurantid)
                .ToList();

            var reservesDelDia = _context.Reservas
                .Where(r => r.datareserva.Date == novaReserva.datareserva.Date && r.estatid == (int)EstatReserva.EnProces) 
                .ToList();

            Taula taulaDisponible = null;

            foreach (var taula in taules)
            {
                var reservesTaula = reservesDelDia.Where(r => r.taulaid == taula.id);

                bool solapada = false;

                foreach (var r in reservesTaula)
                {
                    var horaExistente = r.hora;
                    var duracioExistente = r.durada;

                    var fiNova = novaReserva.hora.Value.Add(TimeSpan.FromMinutes(novaReserva.durada));
                    var fiExistente = horaExistente.Value.Add(TimeSpan.FromMinutes(duracioExistente));

                    if (novaReserva.hora < fiExistente && horaExistente < fiNova)
                    {
                        solapada = true;
                        break;
                    }
                }

                if (!solapada)
                {
                    taulaDisponible = taula;
                    break;
                }
            }

            if (taulaDisponible == null)
                return BadRequest("No hi ha cap taula disponible per a aquest horari.");

            // Assign the available table to the reservation
            novaReserva.taulaid = taulaDisponible.id;
            novaReserva.estatid = (int)EstatReserva.EnProces; 

            _context.Reservas.Add(novaReserva);
            await _context.SaveChangesAsync();

            return Ok("Reserva afegida amb èxit.");
        }

        [HttpPut("CancelarReserva")]
        public async Task<IActionResult> CancelarReserva(int reservaid)
        {
            var reserva = await _context.Reservas.FindAsync(reservaid);

            if (reserva == null)
                return NotFound("Reserva no trobada.");

            reserva.estatid = (int)EstatReserva.Cancelada; 

            await _context.SaveChangesAsync();

            return Ok("Reserva cancel.lada amb èxit.");
        }
    }
}
