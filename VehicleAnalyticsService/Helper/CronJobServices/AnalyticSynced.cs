using VehicleAnalyticsService.Abstraction;
using VehicleAnalyticsService.Helper.CronJobServices.CronJobExtensionMethods;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace VehicleAnalyticsService.Helper.CronJobServices
{
    public class AnalyticSynced : CronJobService, IDisposable
    {
        private readonly IServiceScope _scope;
        public AnalyticSynced(IScheduleConfig<AnalyticSynced> config, IServiceProvider scope) : base(config.CronExpression, config.TimeZoneInfo)
        {
            _scope = scope.CreateScope();
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        public override Task DoWork(CancellationToken cancellationToken)
        {
            IVehicleAnalyticsRepository _analyticsRepository = _scope.ServiceProvider.GetRequiredService<IVehicleAnalyticsRepository>();
            try
            {
                //_analyticsRepository.InsertAnalyticsFromLinks();
            }
            catch (Exception) { }
            return Task.CompletedTask;
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
        public override void Dispose()
        {
            _scope?.Dispose();
        }
    }
}
