using DataLayer.Entityes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class ApplicationUsersModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }
        public string Password { get; set; }
       
    }
    public class ApplicationUsersModelNoPassord
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }

    }
    public class ApplicationUsersUpdateModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
