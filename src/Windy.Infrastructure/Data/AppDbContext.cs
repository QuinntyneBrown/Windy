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
        public DbSet<AssignedOrder> AssignedOrders { get; private set; }
        public DbSet<AssignedOrderStatus> AssignedOrderStatuses { get; private set; }
        public DbSet<JobTitle> JobTitles { get; private set; }
        public DbSet<Role> Roles { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Order> Orders { get; private set; }
        public DbSet<OrderStatus> OrderStatuses { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainerName("WindyDocuments");

            modelBuilder.Entity<AssignedOrder>()
                .HasKey(t => new { t.EmployeeId, t.OrderId });

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
