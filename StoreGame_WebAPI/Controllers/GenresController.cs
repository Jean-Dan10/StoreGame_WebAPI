using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.Data;
using StoreGame_WebAPI.entities;

namespace StoreGame_WebAPI.Controllers
{
    [Route("api/GameStore/Genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GameContext _context;

        public GenresController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
          if (_context.Genres == null)
          {
              return NotFound();
          }
            return await _context.Genres.ToListAsync();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
          if (_context.Genres == null)
          {
              return NotFound();
          }
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound("Aucun genre avec le id suivant : " + id);
            }

            return genre;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.IdGenre)
            {
                return BadRequest("Le id ne concorde pas avec la requête");
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return NotFound("Aucun genre avec le id suivant : " + id);
                }
                else
                {
                    throw;
                }
            }

            var GenreMAJ = await _context.Genres.FindAsync(id);


            return Ok(new { Message = "Genre mise-à-jour avec succès", Client = GenreMAJ });
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
          if (_context.Genres == null)
          {
              return Problem("Entity set 'GameContext.Genres'  is null.");
          }
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.IdGenre }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            if (_context.Genres == null)
            {
                return NotFound();
            }
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound("Aucun Genre avec le id suivant : " + id);
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return Ok("Le Genre avec le ID :" + id + " à été supprimé avec succès");
        }

        private bool GenreExists(int id)
        {
            return (_context.Genres?.Any(e => e.IdGenre == id)).GetValueOrDefault();
        }
    }
}
