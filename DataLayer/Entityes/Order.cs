using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entityes
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int OrderNumber{ get; set; }
        public string Status { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer{ get; set; }
        public List<OrderItem> OrderItems{ get; set; }
    }
}
