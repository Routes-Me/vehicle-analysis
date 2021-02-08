using Microsoft.EntityFrameworkCore;

namespace VehicleAnalyticsService.Models.DBModels
{
    public partial class VehicleAnalyticsServiceContext : DbContext
    {
        public VehicleAnalyticsServiceContext()
        {
        }

        public VehicleAnalyticsServiceContext(DbContextOptions<VehicleAnalyticsServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OperationLogs> OperationLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<OperationLogs>(entity =>
            {
                entity.HasKey(e => e.OperationLogId).HasName("PRIMARY");

                entity.ToTable("operation_logs");

                entity.Property(e => e.OperationLogId).HasColumnName("operation_log_id");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
