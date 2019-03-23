using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Windy.Core.Entities;

namespace Windy.Core.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Company> Companies { get;}
        DbSet<Customer> Customers { get; }
        DbSet<Employee> Employees { get;}
        DbSet<AssignedOrder> AssignedOrders { get;}
        DbSet<AssignedOrderStatus> AssignedOrderStatuses { get;}
        DbSet<JobTitle> JobTitles { get;}
        DbSet<Role> Roles { get;}
        DbSet<User> Users { get;}
        DbSet<Order> Orders { get;}
        DbSet<OrderStatus> OrderStatuses { get;}
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
