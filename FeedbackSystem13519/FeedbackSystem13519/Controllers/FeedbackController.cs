using FeedbackSystem13519.Data;
using FeedbackSystem13519.Models;
using FeedbackSystem13519.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem13519.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IRepository<Feedback> _feedbackRepository;

        public FeedbackController(IRepository<Feedback> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Feedback>> GetAll() => await _feedbackRepository.GetAllAsync();



        [HttpGet("id")]
        [ProducesResponseType(typeof(Feedback), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetByID(int id)
        {
            var resultedToDo = await _feedbackRepository.GetByIDAsync(id);
            return resultedToDo == null ? NotFound() : Ok(resultedToDo);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Create(Feedback items)
        {
            await _feedbackRepository.AddAsync(items);

            return CreatedAtAction(nameof(GetByID), new { id = items.Id }, items);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Feedback items)
        {
            await _feedbackRepository.UpdateAsync(items);

            return NoContent();
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _feedbackRepository.DeleteAsync(id);
            return NoContent();


        }


    }
}
