using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;
using PresentationLayer.Servieces.Interfaces;

namespace InternetMagazin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemServieces _itemServieces;

        public ItemController(IItemServieces itemServieces)
        {
            _itemServieces = itemServieces;
        }



        // GET: api/Item
        [HttpGet]
        [Authorize]
        public IActionResult GetItem()
        {
             return Ok(_itemServieces.GetItemsListToViewModel());
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles ="manager")]
        public IActionResult Create([FromBody] ItemCreateModel item)
        {
            return Ok(_itemServieces.SaveItemCreateModelToDb(item));
        }
        
        [HttpPut]
        [Route("update")]
        [Authorize(Roles ="manager")]
        public IActionResult Put([FromBody] ItemUpdateModel model)
        {
            return Ok(_itemServieces.UpdateItemModel(model));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public void Delete(int id)
        {
            _itemServieces.DeleteItemModel(id);
        }
    }
}
