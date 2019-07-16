using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entityes
{
    public class ApplicationUsers : IdentityUser
    {
       
        public string FullName { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
