using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windy.Core.Entities
{
    public class Order
    {
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey("Status")]
        public Guid OrderStatusId { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public float Amount { get; set; }
        public bool IsAssemblyRequired { get; set; }
        public Company Company { get; set; }
        public OrderStatus Status { get; set; }
    }
}
