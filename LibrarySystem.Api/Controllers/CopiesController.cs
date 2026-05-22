using LibrarySystem.Domain.Entities;
using LibrarySystem.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CopiesController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public CopiesController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var copies = await _context.Copies.Include(c => c.Book).ToListAsync();
            return Ok(copies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var copy = await _context.Copies.Include(c => c.Book).FirstOrDefaultAsync(c => c.Id == id);
            if (copy == null) return NotFound();
            return Ok(copy);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Copy copy)
        {
            _context.Copies.Add(copy);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = copy.Id }, copy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Copy copy)
        {
            if (id != copy.Id) return BadRequest();
            _context.Entry(copy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var copy = await _context.Copies.FindAsync(id);
            if (copy == null) return NotFound();
            _context.Copies.Remove(copy);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
