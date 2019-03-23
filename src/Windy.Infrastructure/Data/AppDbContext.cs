using Microsoft.EntityFrameworkCore;
using Windy.Core.Entities;
using Windy.Core.Interfaces;

namespace Windy.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Address> Addresses { get; private set; }
        public DbSet<Company> Companies { get; private set; }
        public DbSet<Customer> Customers { get; private set; }
        public DbSet<Employee> Employees { get; private set; }
        public DbSet<AssignedWorkOrder> AssignedWorkOrders { get; private set; }
        public DbSet<AssignedWorkOrderStatus> AssignedWorkOrderStatuses { get; private set; }
        public DbSet<JobTitle> JobTitles { get; private set; }
        public DbSet<Role> Roles { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<WorkOrder> WorkOrders { get; private set; }
        public DbSet<WorkOrderStatus> WorkOrderStatuses { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainerName("WindyDocuments");

            modelBuilder.Entity<AssignedWorkOrder>()
                .HasKey(t => new { t.EmployeeId, t.WorkOrderId });

            modelBuilder.Entity<UserRole>()
                .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<Company>()
                .OwnsOne<Address>("Address");
            
            modelBuilder.Entity<Customer>()
                .OwnsOne<Address>("Address");

            base.OnModelCreating(modelBuilder);
        }
    }
}
