using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sweet.API.Data;
using Sweet.API.Models;

namespace Sweet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SweetsController : ControllerBase
    {
        private readonly SweetDbContext _context;

        public SweetsController(SweetDbContext context)
        {
            _context = context;
        }

        // GET: api/sweets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sweet>>> GetSweets()
        {
            return await _context.Sweets.ToListAsync();
        }

        // GET: api/sweets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sweet>> GetSweet(int id)
        {
            var sweet = await _context.Sweets.FindAsync(id);
            if (sweet == null)
                return NotFound(new { message = $"Produkti me ID {id} nuk u gjet." });

            return sweet;
        }

        // GET: api/sweets/search?q=çokollatë
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Sweet>>> SearchSweets([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return await _context.Sweets.ToListAsync();

            return await _context.Sweets
                .Where(s => s.Name.Contains(q) || s.Category.Contains(q) || s.Description.Contains(q))
                .ToListAsync();
        }

        // GET: api/sweets/category/Çokollatë
        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<Sweet>>> GetByCategory(string category)
        {
            return await _context.Sweets
                .Where(s => s.Category == category)
                .ToListAsync();
        }

        // POST: api/sweets
        [HttpPost]
        public async Task<ActionResult<Sweet>> CreateSweet(Sweet sweet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            sweet.CreatedAt = DateTime.UtcNow;
            _context.Sweets.Add(sweet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSweet), new { id = sweet.Id }, sweet);
        }

        // PUT: api/sweets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSweet(int id, Sweet sweet)
        {
            if (id != sweet.Id)
                return BadRequest(new { message = "ID nuk përputhet." });

            _context.Entry(sweet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Sweets.Any(e => e.Id == id))
                    return NotFound(new { message = $"Produkti me ID {id} nuk u gjet." });
                throw;
            }

            return NoContent();
        }

        // DELETE: api/sweets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSweet(int id)
        {
            var sweet = await _context.Sweets.FindAsync(id);
            if (sweet == null)
                return NotFound(new { message = $"Produkti me ID {id} nuk u gjet." });

            _context.Sweets.Remove(sweet);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Produkti '{sweet.Name}' u fshi me sukses." });
        }
    }
}
