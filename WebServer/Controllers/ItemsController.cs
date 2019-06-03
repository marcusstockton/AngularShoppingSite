using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebServer.Interfaces;
using WebServer.Models;
using WebServer.Models.DTOs.Items;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _service;
        private readonly IImageService _imageService;

        public ItemsController(IItemsService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
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
        /// <param name="item">The Item data</param>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ItemCreate item)
        {
            var result = await _service.CreateItem(item);
            if(result > 0)
            {
                // Return the number of records added:
                return Ok(result);
            }
            return BadRequest();
        }

        // PUT api/values/5

        /// <summary>
        /// Updates a cerain Item
        /// </summary>
        /// <param name="id">The item Id</param>
        /// <param name="item">The Item</param>
        /// <param name="fileArray">The Files</param>
        /// <returns>An IActionResult</returns>
        [DisableRequestSizeLimit]
        [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(string id, [ModelBinder(BinderType = typeof(JsonModelBinder))] ItemEdit item, List<IFormFile> fileArray)
        {
            Guid _id;
            var idGuid = Guid.TryParse(id, out _id);

            if (idGuid && item != null)
            {
                // Check if the request contains multipart/form-data.
                if (fileArray.Any())
                {
                    // we have files...
                    await _imageService.UploadImages(fileArray, _id);
                }

                var result = await _service.UpdateItemById(_id, item);
                if (result)
                {
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

        /// <summary>
        /// Deletes an Item
        /// </summary>
        /// <param name="id">The Id of the Item</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                Guid itemId;
                Guid.TryParse(id, out itemId);
                var result = await _service.DeleteItemById(itemId);
                if(result){
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
