using VehicleAnalyticsService.Abstraction;
using VehicleAnalyticsService.Models;
using VehicleAnalyticsService.Models.Common;
using VehicleAnalyticsService.Models.DBModels;
using VehicleAnalyticsService.Models.ResponseModel;
using Microsoft.Extensions.Options;
using Obfuscation;
using System;
using System.Linq;
using System.Collections.Generic;

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

        public dynamic InsertOpertionLogs(List<OperationLogsDto> operationLogsDtoList)
        {
            if (!operationLogsDtoList.Any() || operationLogsDtoList == null)
                throw new ArgumentNullException(CommonMessage.InvalidData);

            List<OperationLogs> operationLogsList = new List<OperationLogs>();

            foreach (var operationLogsDto in operationLogsDtoList)
            {
                operationLogsList.Add(new OperationLogs
                {
                    DeviceId = ObfuscationClass.DecodeId(Convert.ToInt32(operationLogsDto.DeviceId), _appSettings.PrimeInverse),
                    Duration = operationLogsDto.Duration,
                    Date = operationLogsDto.Date,
                    CreatedAt = DateTime.Now
                });
            }

            return operationLogsList;
        }
    }
}
