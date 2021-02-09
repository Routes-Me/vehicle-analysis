using System.Collections.Generic;
using VehicleAnalyticsService.Models.ResponseModel;

namespace VehicleAnalyticsService.Abstraction
{
    public interface IVehicleAnalyticsRepository
    {
        dynamic InsertOpertionLogs(List<OperationLogsDto> operationLogsDtoList);
    }
}
