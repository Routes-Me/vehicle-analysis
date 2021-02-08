using System;

namespace VehicleAnalyticsService.Models.ResponseModel
{
    public class OperationLogsDto
    {
        public int OperationLogId { get; set; }
        public string DeviceId { get; set; }
        public float Duration { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
