using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Interfaces;
using WebServer.Models;
using WebServer.Models.DTOs.Items;
using WebServer.Models.Items;

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
        /// <returns>An IEnumerable of Item details.</returns>
        [HttpGet]
        [EnableCors]
        public async Task<ActionResult<IEnumerable<ItemDetails>>> Get()
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
        [ProducesResponseType(typeof( ItemDetails ), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ItemDetails>> Get(string id)
        {
            var guidId = new Guid();
            var success = Guid.TryParse(id, out guidId);
            if(success)
            {
                var item = await _service.GetItemById(guidId);
                if (item == null)
                {
                    return NotFound();
                }
                //return item;
                return Ok(item);
            }
            else{
                return BadRequest();
            }
        }

        // POST api/values
        /// <summary>
        /// Creates a new Item
        /// </summary>
        /// <param name="item">The Item data</param>
        /// <param name="fileArray">An array of files</param>
        /// <returns>The created Item.</returns>
        [Authorize]
        [HttpPost, DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(ItemCreate item, List<IFormFile> fileArray)
        {
            var images = new List<Image>();
            if (fileArray.Any())
            {
                images = await _imageService.UploadImages(fileArray);
            }
            var result = await _service.CreateItem(item, images);
            if(result.Id != Guid.Empty)
            {
                return CreatedAtAction(nameof(Get), new { id = result.Id.ToString() }, result);
                //return Ok(result);
            }
            return BadRequest();
        }

        // PUT api/values/5

        /// <summary>
        /// Updates a cerain Item
        /// </summary>
        /// <param name="id">The item Id</param>
        /// <param name="item">The raw Item</param>
        /// <param name="fileArray">The Files</param>
        /// <returns>The updated item.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType( StatusCodes.Status201Created )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        [Consumes( "application/json" )]
        [Authorize]
        public async Task<ActionResult> Put(string id, [FromBody]ItemEdit item)
        {
            Guid _id;
            var idGuid = Guid.TryParse(id, out _id);
            if (item == null)
            {
                return BadRequest("Invalid Data");
            }
            if (id != item.Id.ToString())
            {
                return BadRequest( "Id's do not match!" );
            }
            if (idGuid && item != null)
            {
                var result = await _service.UpdateItemById( _id, item );
                if (result != null)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest( "Invalid Data" );
                }
            }

            return BadRequest("Empty Item record passed down doofus!");
        }

        // DELETE api/values/5

        /// <summary>
        /// Deletes an Item
        /// </summary>
        /// <param name="id">The Id of the Item</param>
        /// <returns>200 If Sucessful</returns>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                Guid itemId;
                Guid.TryParse(id, out itemId);
                var result = await _service.DeleteItemById(itemId);
                if(result){
                    return NoContent();
                }
            }
            return BadRequest();
        }
    }
}
