using Microsoft.AspNetCore.Mvc;
using RestWebApi.Contracts;
using RestWebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        AppDbContext _context;
        public ValuesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = nameof(GetAllProducts))]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public async Task<IActionResult> GetAllProducts()
        {
            IAsyncGenericRepository<Student> repo = new AsyncGenericRepository<Student>(_context);
            var result = await repo.GetAllAsync();
            return this.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            IAsyncGenericRepository<Student> repo = new AsyncGenericRepository<Student>(_context);
            var result = await repo.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost(Name = nameof(AddNewStudent))]
        [ProducesResponseType(200, Type = typeof(Student))]
        public async Task<ActionResult<Product>> AddNewStudent(Student s)
        {
            IAsyncGenericRepository<Student> repo = new AsyncGenericRepository<Student>(_context);
            var newProductAfterInsert = await repo.InsertAsync(s);
            await _context.SaveChangesAsync();
            return Created("products/" + newProductAfterInsert.Id, newProductAfterInsert);
        }

        [HttpDelete("{id}", Name = nameof(DeleteProduct))]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            IAsyncGenericRepository<Student> repo = new AsyncGenericRepository<Student>(_context);
            await repo.DeleteAsync(id);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
