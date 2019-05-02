using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServer.Interfaces;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _service;

        public ItemsController(IItemsService service)
        {
            _service = service;
        }

        // GET api/values
		// curl https://localhost:5001/api/Items --insecure | python -mjson.tool

        /// <summary>
        /// Gets a list of all Items.
        /// </summary>
        /// <returns>An Ienumerable of Items.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            return Ok(await _service.GetItems());
        }

        // GET api/values/5
        /// <summary>
        /// Get a specific item.
        /// </summary>
        /// <param name="id">The Item Id.</param>
        /// <returns>An Item.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(string id)
        {
            var idGuid = Guid.Parse(id);
            var item = await _service.GetItemById(idGuid);
            return Ok(item);
        }

        // POST api/values

        /// <summary>
        /// Creates a new Item
        /// </summary>
        /// <param name="value">The Item data</param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5

        /// <summary>
        /// Updates a cerain Item
        /// </summary>
        /// <param name="id">The item Id</param>
        /// <param name="item">The Item</param>
        /// <returns>An IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Item item)
        {
            Guid _id;
            var idGuid = Guid.TryParse(id, out _id);
            if (idGuid && item != null)
            {
                var result = await _service.UpdateItemById(_id, item);
                if(result){
                    return NoContent();
                } 
                else 
                {
                    return BadRequest("Invalid Data");
                }
            }
            
            return BadRequest("Empty Item record passed down doofus!");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
