using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models.DTOs.Reviews;
using WebServer.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;


        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        // curl https://localhost:5001/api/Review/0b62806d-4d1b-4f8b-9747-a9fcea77d53c --insecure | python -mjson.tool
        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetReviewsForItem(string itemId)
        {
            return Ok(await _service.GetReviewsForItem(Guid.Parse(itemId)));
        }

        // curl https://localhost:5001/api/Review/0b62806d-4d1b-4f8b-9747-a9fcea77d53c/86f58abf-a1f1-4094-84ad-1ac369a32732 --insecure | python -mjson.tool
        [HttpGet("{itemId}/{reviewId}")]
        public async Task<IActionResult> GetReviewById(Guid itemId, Guid reviewId)
        {
            var review = await _service.GetReviewById(itemId, reviewId);
            if(review != null)
            {
                return Ok(review);
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReview( ReviewCreate review)
        {
            var result = await _service.CreateReview(review);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> ReviewEdit(Guid id, ReviewEdit review)
        {
            var result = await _service.UpdateReviewById(id, review);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            var result = await _service.DeleteReviewById(id);
            return Ok();
        }
    }
}
