using Data;
using Entitats.ReservaClasses;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Services
{
    public class ReservaService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;

        public ReservaService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.Now;
            var nextQuarter = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute / 15 * 15, 0).AddMinutes(15);
            var initialDelay = nextQuarter - now;

            _timer = new Timer(DoWork, null, initialDelay, TimeSpan.FromMinutes(15));
            return Task.CompletedTask;
        }


        private void DoWork(object state)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();

            var ara = DateTime.Now;

            var reservesPendents = dbContext.Reservas.Where(r => r.estatid == (int)EstatReserva.EnProces).ToList();

            foreach (var reserva in reservesPendents)
            {
                if (reserva.hora.HasValue)
                {
                    var iniciDateTime = reserva.datareserva.Date + reserva.hora.Value;
                    var fi = iniciDateTime.AddMinutes(reserva.durada);

                    if (ara > fi)
                    {
                        reserva.estatid = (int)EstatReserva.Finalitzada;
                    }
                }
            }

            dbContext.SaveChanges();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
