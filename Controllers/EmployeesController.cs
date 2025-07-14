using Microsoft.AspNetCore.Mvc;
using WebApiCoreCruds1.Interfaces;
using WebApiCoreCruds1.Models;

namespace WebApiCoreCruds1.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _repo;
        public EmployeesController(IEmployeesRepository repository)
        {
            _repo = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllEmployeesAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await _repo.GetEmployeeByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee product)
        {
            var newProduct = await _repo.AddEmployeeAsync(product);
            return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Employee product)
        {
            if (id != product.Id) return BadRequest();
            var updated = await _repo.UpdateEmployeeAsync(product);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _repo.DeleteEmployeeAsync(id);
            return deleted ? NoContent() : NotFound();
        }

    }
}
