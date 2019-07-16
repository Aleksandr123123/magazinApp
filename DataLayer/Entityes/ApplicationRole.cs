using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entityes
{
    public class ApplicationRole: IdentityRole
    {
        public ApplicationRole()
        {
        }
        public ApplicationRole(string roleName): base(roleName)
        {
        }

        
       
    }

}
