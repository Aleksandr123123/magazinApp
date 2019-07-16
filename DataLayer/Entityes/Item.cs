using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entityes
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
