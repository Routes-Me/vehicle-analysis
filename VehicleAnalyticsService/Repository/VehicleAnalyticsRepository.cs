using VehicleAnalyticsService.Abstraction;
using VehicleAnalyticsService.Models;
using VehicleAnalyticsService.Models.Common;
using VehicleAnalyticsService.Models.DBModels;
using VehicleAnalyticsService.Models.ResponseModel;
using Microsoft.Extensions.Options;
using Obfuscation;
using System;

namespace VehicleAnalyticsService.Repository
{
    public class VehicleAnalyticsRepository : IVehicleAnalyticsRepository
    {
        private readonly AppSettings _appSettings;
        private readonly VehicleAnalyticsServiceContext _context;
        public VehicleAnalyticsRepository(IOptions<AppSettings> appSettings, VehicleAnalyticsServiceContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public dynamic InsertOpertionLogs(OperationLogsDto operationLogsDto)
        {
            if (string.IsNullOrEmpty(operationLogsDto.DeviceId) || operationLogsDto == null)
                throw new ArgumentNullException(CommonMessage.InvalidData);

            OperationLogs operationLog = new OperationLogs();
            operationLog.DeviceId = ObfuscationClass.DecodeId(Convert.ToInt32(operationLogsDto.DeviceId), _appSettings.PrimeInverse);
            operationLog.Duration = operationLogsDto.Duration;
            operationLog.Date = operationLogsDto.Date;
            operationLog.CreatedAt = DateTime.Now;

            return operationLog;
        }
    }
}
