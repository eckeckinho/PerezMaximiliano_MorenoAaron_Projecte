﻿using Data;
using Entitats.AuthClasses;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Entitats.TaulaClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Services
{
    public class ReservaService : IReservaService
    {
        private readonly DBContext _context;
        private readonly Restaurant _restaurantActual;

        public ReservaService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            _restaurantActual = restContext.restaurantActual;
        }

        public bool AfegirReserva(Reserva newReserva)
        {
            try
            {
                if (newReserva == null) return false;

                newReserva.restaurantid = _restaurantActual.id; 

                _context.Reservas.Add(newReserva);
                _context.SaveChanges();

                var usuari = _context.Usuaris.FirstOrDefault(u => u.id == newReserva.usuariId);
                if (usuari != null)
                {
                    if (EsCorreoValido(usuari.correu) && EsCorreoValido(_restaurantActual.correu)) EnviarCorreuConfirmacio(usuari, newReserva);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al afegir la reserva. " + ex.Message, ex);
            }
        }

        public bool CanviarEstatReserva(List<Reserva> reservesSeleccionades, int nouEstat)
        {
            if (reservesSeleccionades == null || reservesSeleccionades.Count == 0) return false;

            if (nouEstat == (int)EstatReserva.EnProces)
            {
                foreach (var reserva in reservesSeleccionades)
                {
                    if (HiHaSolapamentReserva(reserva))
                    {
                        // No se puede cambiar a "En procés" porque hay solapamiento
                        return false;
                    }
                }
            }

            foreach (Reserva reserva in reservesSeleccionades)
            {
                reserva.estatid = nouEstat;
                _context.Reservas.Update(reserva);
            }

            int changes = _context.SaveChanges();

            return changes > 0;
        }


        public List<Reserva> GetReservesRestaurant(int idEstat, DateTime desde, DateTime hasta, Usuari usuari)
        {
            var idTaulesRestaurant = _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).Select(x => x.id).ToList();

            if (idTaulesRestaurant.Count == 0) return new List<Reserva>();

            var query = _context.Reservas
                .Where(x => idTaulesRestaurant.Contains(x.taulaid))
                .Where(x => x.estatid == idEstat)
                .Where(x => x.datareserva >= desde.Date && x.datareserva < hasta.Date.AddDays(1));

            if (usuari != null && usuari.id != -1) query = query.Where(x => x.usuariId == usuari.id);

            return query.OrderByDescending(x => x.id).ToList();
        }

        public Usuari GetUsuariReserva(int usuariId)
        {
            try
            {
                var usuari = _context.Usuaris.Where(x => x.id == usuariId).FirstOrDefault();

                if (usuari == null)
                {
                    return null;
                }
                else
                {
                    return usuari;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al trobar l'usuari. " + ex.Message, ex);
            }
        }

        public List<Reserva> GetReservesDia(DateTime dia)
        {
            var idTaulesRestaurant = _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).Select(x => x.id).ToList();

            if (idTaulesRestaurant.Count == 0) return new List<Reserva>();

            // Devuelve las reservas pendientes del restaurante filtrados por día
            var reservasDelDia = _context.Reservas.Where(x => idTaulesRestaurant.Contains(x.taulaid)).Where(x => x.datareserva.Date == dia.Date)
                .Where(x => x.estatid == (int)EstatReserva.EnProces).OrderBy(x => x.datareserva).ToList();

            return reservasDelDia;
        }

        public Taula GetTaulaDisponible(int? numComensals, DateTime data, TimeSpan? novaHora, int novaDurada, int? reservaIdAExcloure)
        {
            // Coger las mesas del rest por numero de comensales
            var taules = _context.Taules.Where(t => t.numComensals == numComensals && t.restaurantId == _restaurantActual.id).ToList();

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

        public bool ActualitzarReserva(Reserva reserva)
        {
            try
            {
                if (reserva == null) return false;

                var reservaExistente = _context.Reservas.Find(reserva.id);

                if (reservaExistente == null) return false;

                reservaExistente.datareserva = reserva.datareserva;
                reservaExistente.numcomensals = reserva.numcomensals;
                reservaExistente.taulaid = reserva.taulaid;
                reservaExistente.durada = reserva.durada;
                reservaExistente.hora = reserva.hora;
                reservaExistente.usuariId = reserva.usuariId;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualitzar la reserva. " + ex.Message, ex);
            }
        }

        public int GetCountReservesByEstatUsuari(int estatId, int usuariId, DateTime desde, DateTime hasta)
        {
            var idTaulesRestaurant = _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).Select(x => x.id);

            var reserves = _context.Reservas.Where(r => idTaulesRestaurant.Contains(r.taulaid)).Where(r => r.estatid == estatId).Where(r => r.datareserva >= desde.Date && r.datareserva < hasta.Date.AddDays(1));

            if (usuariId != -1) reserves = reserves.Where(r => r.usuariId == usuariId);

            return reserves.Count();
        }

        #region helpers
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

        private bool HiHaSolapamentReserva(Reserva reserva)
        {
            var reservesEnProces = _context.Reservas
                .Where(r => r.estatid == (int)EstatReserva.EnProces
                            && r.taulaid == reserva.taulaid
                            && r.datareserva == reserva.datareserva
                            && r.id != reserva.id)
                .ToList();

            foreach (var rExist in reservesEnProces)
            {
                if (SolapaAmbReservaExistente(reserva.hora, reserva.durada, rExist.hora, rExist.durada))
                {
                    return true; // Hay solapamiento
                }
            }

            return false; // No hay solapamiento
        }

        private bool EsCorreoValido(string correo)
        {
            try
            {
                var mail = new MailAddress(correo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void EnviarCorreuConfirmacio(Usuari usuari, Reserva reserva)
        {
            var fromAddress = new MailAddress(_restaurantActual.correu, _restaurantActual.nomRestaurant);
            var toAddress = new MailAddress(usuari.correu, usuari.nom);

            const string subject = "Confirmació de la teva reserva";

            byte[] logoBytes = _restaurantActual.logo;
            MemoryStream logoStream = new MemoryStream(logoBytes);

            LinkedResource logo = new LinkedResource(logoStream, "image/png")
            {
                ContentId = "logoCid",
                TransferEncoding = System.Net.Mime.TransferEncoding.Base64
            };

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
                    <p style='font-weight: bold; color: #000000; font-size: 14px;'>Restaurant {_restaurantActual.nomRestaurant}</p>
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
        }

        #endregion

    }
}
