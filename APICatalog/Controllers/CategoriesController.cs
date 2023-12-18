using APICatalog.Context;
using APICatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Category>> GetCategoriesProducts()
        {
            //return _context.Categories.Include(p => p.Products).AsNoTracking().ToList();
            return _context.Categories.Include(p => p.Products).Where(c => c.CategoryId <= 5).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _context.Categories.AsNoTracking().ToList(); 
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Category> Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category is null)
            {
                return NotFound("Categoria não encontrada");
            }
            
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (category is null)
            {
                return BadRequest();
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterCategoria",
                new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}:int")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (category is null) return NotFound("Categoria não localizada...");

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }
    }
}
