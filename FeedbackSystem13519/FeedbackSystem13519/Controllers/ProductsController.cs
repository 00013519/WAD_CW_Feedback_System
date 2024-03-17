using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeedbackSystem13519.Data;
using FeedbackSystem13519.Models;
using FeedbackSystem13519.Repositories;

namespace FeedbackSystem13519.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }









        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _repository.GetAllAsync();
        }








        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var resultedProduct = await _repository.GetByIDAsync(id);
            if (resultedProduct == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resultedProduct);
            }
        }







        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Create(Product products)
        {
            await _repository.AddAsync(products);
            return CreatedAtAction(nameof(GetByID), new { id = products.Id }, products);
        }







        // PUT api/<CategoryController>/5
        [HttpPut]
        public async Task<IActionResult> Update(Product products)
        {
            //if(id!=items.ID) return BadRequest();
            await _repository.UpdateAsync(products);
            return NoContent();
        }






        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
