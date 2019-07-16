using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entityes
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int ItemsCount { get; set; }
        [Required]
        public int ItemPrice { get; set; }
        public Order Order{ get; set; }
        public Item Item{ get; set; }
    }
}
