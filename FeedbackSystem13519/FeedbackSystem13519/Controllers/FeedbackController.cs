using FeedbackSystem13519.Data;
using FeedbackSystem13519.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem13519.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackDBContext _feedbackDbContext;
        public FeedbackController(FeedbackDBContext feedbackDBContext)
        {
            _feedbackDbContext = feedbackDBContext;
        }

        [HttpGet]
        public async Task<IEnumerable<FeedbackItems>> GetAll() => await _feedbackDbContext.FeedbackItems.ToArrayAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(FeedbackItems), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetByID(int id)
        {
            var resultedToDo = await _feedbackDbContext.FeedbackItems.FindAsync(id);
            return resultedToDo == null ? NotFound() : Ok(resultedToDo);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Create(FeedbackItems items)
        {
            await _feedbackDbContext.FeedbackItems.AddAsync(items);
            await _feedbackDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByID), new { id = items.Id }, items);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, FeedbackItems items)
        {
            if (id != items.Id) return BadRequest();
            _feedbackDbContext.Entry(items).State = EntityState.Modified;
            await _feedbackDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var todoItemtoDelete = await _feedbackDbContext.FeedbackItems.FindAsync(id);
            if (todoItemtoDelete == null) return NotFound();

            _feedbackDbContext.FeedbackItems.Remove(todoItemtoDelete);
            await _feedbackDbContext.SaveChangesAsync();
            return NoContent();


        }


    }
}
