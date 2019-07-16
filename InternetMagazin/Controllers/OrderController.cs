using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.Servieces.Interfaces;

namespace InternetMagazin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private IOrderServieces _orderServieces;

        public OrderController(IOrderServieces orderServieces)
        {
            _orderServieces = orderServieces;
        }



        // GET: api/Order
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderServieces.GetOrdersListToViewModel());
        }

        // GET: api/Order/5
        [HttpGet("getByNumber/{id}")]
        [Authorize]

        public IActionResult GetByUser(int id)
        {
            return Ok(_orderServieces.GetOrdersByUser(id));
        }

        // POST: api/Order
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] OrderCreateModel model)
        {
            return Ok(_orderServieces.SaveOrderCreateModelToDb(model));
        }
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            _orderServieces.DeleteOrder(id);
        }

        // PUT: api/Order/5
        [HttpPut]
        [Authorize(Roles = "manager")]
        public void Put([FromBody] OrderUpdateModel model)
        {
            _orderServieces.UpdateOrderStatus(model);
        }

       
    }
}
