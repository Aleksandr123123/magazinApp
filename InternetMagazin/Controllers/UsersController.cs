using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.Servieces.Interfaces;

namespace InternetMagazin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ICustomerServieces _customerServieces;

        public UsersController(ICustomerServieces customerServieces)
        {
            _customerServieces = customerServieces;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize(Roles ="manager")]
        public IActionResult GetUsers()
        {
            List<CustomerViewModel> modle = _customerServieces.GetCustomersListToViewModel();
            return Ok(_customerServieces.GetCustomersListToViewModel());
        }
        

        // POST: api/Users
        [HttpPost("createCustomer")]
        public async Task<IActionResult> Create([FromBody] CustomerCreateModel customer)
        {

            var result = await _customerServieces.CreateCustomer(customer);
          
                return Ok(result);
          
        }
        [HttpPost("createUser")]
        public async Task<IActionResult> Create([FromBody]ApplicationUsersModel user)
        {


            var result = await _customerServieces.CreateUser(user);
                    return Ok(result);
              
        }

        // PUT: api/Users/5
        [HttpPut("updateUser")]
        public async Task<IActionResult> Update([FromBody] ApplicationUsersUpdateModel model)
        {
            return Ok(await _customerServieces.UpdateUser(model));
        }
        [HttpPut("updateCustomer")]
        public IActionResult Update([FromBody] CustomerUpdateModel model)
        {
            return Ok( _customerServieces.UpdateCustomer(model));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("customer/{id}")]
        public async Task Delete(int id)
        {
           await _customerServieces.DeleteCustomer(id);
        }

        [HttpDelete("user/{id}")]
        public async Task Delete(string id)
        {
            await _customerServieces.DeleteUser(id);
        }
    }
}
