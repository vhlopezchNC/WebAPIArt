using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiArt.Data;
using WebApiArt.Models;

namespace WebApiArt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtTypeController : ControllerBase
    {
        private readonly ArtContext _context;

        public ArtTypeController(ArtContext context)
        {
            _context = context;
        }

        // GET: api/ArtType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtType>>> GetArtTypes()
        {
            return await _context.ArtTypes
                .Include(at =>at.Artworks)
                .ToListAsync();
        }

        // GET: api/ArtType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtType>> GetArtType(int id)
        {
            var artType = await _context.ArtTypes.FindAsync(id);

            if (artType == null)
            {
                return NotFound();
            }

            return artType;
        }

        // PUT: api/ArtType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtType(int id, ArtType artType)
        {
            if (id != artType.ID)
            {
                return BadRequest();
            }

            _context.Entry(artType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ArtType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtType>> PostArtType(ArtType artType)
        {
            _context.ArtTypes.Add(artType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtType", new { id = artType.ID }, artType);
        }

        // DELETE: api/ArtType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtType(int id)
        {
            var artType = await _context.ArtTypes.FindAsync(id);
            if (artType == null)
            {
                return NotFound();
            }

            _context.ArtTypes.Remove(artType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtTypeExists(int id)
        {
            return _context.ArtTypes.Any(e => e.ID == id);
        }
    }
}
