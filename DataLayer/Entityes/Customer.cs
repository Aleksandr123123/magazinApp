using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entityes
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }
        public List<Order> Orders { get; set; }
        [Required]
        public ApplicationUsers User { get; set; }
        public string UserId { get; set; }
    }
}
