using VehicleAnalyticsService.Models.ResponseModel;

namespace VehicleAnalyticsService.Abstraction
{
    public interface IVehicleAnalyticsRepository
    {
        dynamic InsertOpertionLogs(OperationLogsDto operationLogsDto);
    }
}
