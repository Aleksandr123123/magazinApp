using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public ApplicationUsers Users{ get; set; }
    }
    public class CustomerCreateModel
    {
       public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }
        public ApplicationUsersModel Users { get; set; }
    }
    public class CustomerUpdateModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }

    }
}
