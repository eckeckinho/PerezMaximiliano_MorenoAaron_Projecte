using Data;
using Entitats.ReservaClasses;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Services
{
    // Servicio que se ejecuta periódicamente para actualizar el estado de las reservas
    public class ReservaService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;

        public ReservaService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        // Método que se ejecuta al iniciar el servicio
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Calcula cuándo empieza el siguiente cuarto de hora (por ejemplo, si son las 08:32, empieza a las 08:45)
            var now = DateTime.Now;
            var proximoCuarto = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute / 15 * 15, 0).AddMinutes(15);
            // Calcula el tiempo total hasta el siguiente cuarto de hora (13 minutos en este ejemplo)
            var delayInicial = proximoCuarto - now;

            // Inicializa el temporizador para ejecutar el método ActualitzarEstatsDeReserves cada 15 minutos
            _timer = new Timer(ActualitzarEstatsDeReserves, null, delayInicial, TimeSpan.FromMinutes(15));
            return Task.CompletedTask;
        }

        // Método que se ejecuta cada 15 minutos y actualiza el estado de reservas finalizadas
        private void ActualitzarEstatsDeReserves(object state)
        {
            // Crea un nuevo ámbito para obtener una instancia del contexto de base de datos
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();

            var ara = DateTime.Now;

            var reservesPendents = dbContext.Reservas.Where(r => r.estatid == (int)EstatReserva.EnProces).ToList();

            foreach (var reserva in reservesPendents)
            {
                if (reserva.hora.HasValue)
                {
                    // Calcula el DateTime completo de inicio y fin de la reserva
                    var iniciDateTime = reserva.datareserva.Date + reserva.hora.Value;
                    var fi = iniciDateTime.AddMinutes(reserva.durada);

                    // Si la hora actual es posterior al fin de la reserva, se marca como finalizada
                    if (ara > fi)
                    {
                        reserva.estatid = (int)EstatReserva.Finalitzada;
                    }
                }
            }

            dbContext.SaveChanges();
        }

        // Detener la ejecución periódica al detener el servicio
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        // Liberar recursos
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
