using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class LoginModel
    {
      //  [Required(ErrorMessage ="Not Email")]
        public string UserName { get; set; }
      //  [Required(ErrorMessage = "No Password")]
      //  [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
