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
    [Route("api/GameStore/Jeus")]
    [ApiController]
    public class JeusController : ControllerBase
    {
        private readonly GameContext _context;

        public JeusController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Jeus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jeu>>> GetJeux()
        {
            var jeux = await _context.Jeux.ToListAsync();

            if (jeux.Count == 0)
            {
                return NotFound("Aucune données de jeu");
            }

            return jeux;
        }

        // GET: api/Jeus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jeu>> GetJeu(int id)
        {
          if (_context.Jeux == null)
          {
              return NotFound();
          }
            var jeu = await _context.Jeux.FindAsync(id);

            if (jeu == null)
            {
                return NotFound("Aucun genre avec le id suivant : " + id);
            }

            return jeu;
        }

        // PUT: api/Jeus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJeu(int id, Jeu jeu)
        {
            if (id != jeu.IdJeu)
            {
                return BadRequest("Le id ne concorde pas avec la requête");
            }

            _context.Entry(jeu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JeuExists(id))
                {
                    return NotFound("Aucun client avec le id suivant : " + id);
                }
                else
                {
                    throw;
                }
            }

            var JeuMAJ = await _context.Genres.FindAsync(id);


            return Ok(new { Message = "Jeu mise-à-jour avec succès", Client = JeuMAJ });
        }

        // POST: api/Jeus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jeu>> PostJeu(Jeu jeu)
        {
          if (_context.Jeux == null)
          {
              return Problem("Entity set 'GameContext.Jeux'  is null.");
          }
            _context.Jeux.Add(jeu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJeu", new { id = jeu.IdJeu }, jeu);
        }

        // DELETE: api/Jeus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJeu(int id)
        {
            if (_context.Jeux == null)
            {
                return NotFound();
            }
            var jeu = await _context.Jeux.FindAsync(id);
            if (jeu == null)
            {
                return NotFound("Aucun Jeu avec le id suivant : " + id);
            }

            _context.Jeux.Remove(jeu);
            await _context.SaveChangesAsync();

            return Ok("Le Jeu avec le ID :" + id + " à été supprimé avec succès");
        }

        private bool JeuExists(int id)
        {
            return (_context.Jeux?.Any(e => e.IdJeu == id)).GetValueOrDefault();
        }
    }
}
