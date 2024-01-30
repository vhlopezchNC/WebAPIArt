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
    public class ArtworkController : ControllerBase
    {
        private readonly ArtContext _context;

        public ArtworkController(ArtContext context)
        {
            _context = context;
        }

        // GET: api/Artwork
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artwork>>> GetArtworks()
        {
            return await _context.Artworks
                .Include(aw =>aw.ArtType)
                .ToListAsync();
        }

        // GET: api/Artwork/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artwork>> GetArtwork(int id)
        {
            var artwork = await _context.Artworks
                .Include(aw => aw.ArtType)
                .FirstOrDefaultAsync(aw =>aw.ID == id);

            if (artwork == null)
            {
                return NotFound();
            }

            return artwork;
        }

        // PUT: api/Artwork/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtwork(int id, Artwork artwork)
        {
            if (id != artwork.ID)
            {
                return BadRequest();
            }

            _context.Entry(artwork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtworkExists(id))
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

        // POST: api/Artwork
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artwork>> PostArtwork(Artwork artwork)
        {
            _context.Artworks.Add(artwork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtwork", new { id = artwork.ID }, artwork);
        }

        // DELETE: api/Artwork/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtwork(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork == null)
            {
                return NotFound();
            }

            _context.Artworks.Remove(artwork);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtworkExists(int id)
        {
            return _context.Artworks.Any(e => e.ID == id);
        }
    }
}
