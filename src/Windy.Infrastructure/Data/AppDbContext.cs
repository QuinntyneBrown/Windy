using Microsoft.EntityFrameworkCore;
using Windy.Core.Entities;
using Windy.Core.Interfaces;

namespace Windy.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Company> Companies { get; private set; }
        public DbSet<Employee> Employees { get; private set; }
        public DbSet<EmployeeWorkOrder> EmployeeWorkOrders { get; private set; }
        public DbSet<EmployeeWorkOrderStatus> EmployeeWorkOrderStatuses { get; private set; }
        public DbSet<JobTitle> JobTitles { get; private set; }
        public DbSet<Role> Roles { get; private set; }
        public DbSet<Tenant> Tenants { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<WorkOrder> WorkOrders { get; private set; }
        public DbSet<WorkOrderStatus> WorkOrderStatuses { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainerName("WindyDocuments");

            modelBuilder.Entity<EmployeeWorkOrder>()
                .HasKey(t => new { t.EmployeeId, t.WorkOrderId });

            modelBuilder.Entity<EmployeeWorkOrder>()
                .OwnsOne<EmployeeWorkOrderStatus>("EmployeeWorkOrderStatus");

            modelBuilder.Entity<WorkOrder>()
                .OwnsOne<EmployeeWorkOrderStatus>("WorkOrderStatus");

            modelBuilder.Entity<Employee>()
                .HasOne<JobTitle>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
