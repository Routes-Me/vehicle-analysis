using System;

namespace VehicleAnalyticsService.Models.DBModels
{
    public partial class OperationLogs
    {
        public int OperationLogId { get; set; }
        public int DeviceId { get; set; }
        public float Duration { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
