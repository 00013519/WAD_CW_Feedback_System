using FeedbackSystem13519.Data;
using FeedbackSystem13519.Models;
using FeedbackSystem13519.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem13519.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IRepository<FeedbackItems> _feedbackItemsRepository;

        public FeedbackController(IRepository<FeedbackItems> feedbackItemsRepository)
        {
            _feedbackItemsRepository = feedbackItemsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<FeedbackItems>> GetAll() => await _feedbackItemsRepository.GetAllAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(FeedbackItems), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetByID(int id)
        {
            var resultedToDo = await _feedbackItemsRepository.GetByIDAsync(id);
            return resultedToDo == null ? NotFound() : Ok(resultedToDo);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Create(FeedbackItems items)
        {
            await _feedbackItemsRepository.AddAsync(items);

            return CreatedAtAction(nameof(GetByID), new { id = items.Id }, items);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, FeedbackItems items)
        {
            if (id != items.Id) return BadRequest();
            await _feedbackItemsRepository.UpdateAsync(items);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _feedbackItemsRepository.DeleteAsync(id);
            return NoContent();


        }


    }
}
