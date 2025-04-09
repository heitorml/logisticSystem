using Logistic.Delivery.Create.Worker.Sagas;
using Logistic.Delivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistic.Delivery.Create.Worker.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DeliveryModel> Deliveries { get; set; }
        public DbSet<DeliveryCreateSagaData> DeliveryCreateProcesSaga { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DeliveryModel>().HasKey(x => x.DeliveryId);
            modelBuilder.Entity<DeliveryCreateSagaData>().HasKey(x => x.CorrelationId);
        }
    }
}
