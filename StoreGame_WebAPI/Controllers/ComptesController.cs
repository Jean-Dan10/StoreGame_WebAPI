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
    [Route("api/GameStore/Comptes")]
    [ApiController]
    public class ComptesController : ControllerBase
    {
        private readonly GameContext _context;

        public ComptesController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Comptes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compte>>> GetComptes()
        {
            var comptes = await _context.Comptes.ToListAsync();

            if (comptes.Count == 0)
            {
                return NotFound("Aucune données de compte");
            }

            return comptes;
        }

            // GET: api/Comptes/5
            [HttpGet("{id}")]
        public async Task<ActionResult<Compte>> GetCompte(string id)
        {
          if (_context.Comptes == null)
          {
              return NotFound();
          }
            var compte = await _context.Comptes.FindAsync(id);

            if (compte == null)
            {
                return NotFound();
            }

            return compte;
        }

        // PUT: api/Comptes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompte(string id, Compte compte)
        {
            if (id != compte.User)
            {
                return BadRequest();
            }

            _context.Entry(compte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompteExists(id))
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

        // POST: api/Comptes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
          if (_context.Comptes == null)
          {
              return Problem("Entity set 'GameContext.Comptes'  is null.");
          }
            _context.Comptes.Add(compte);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompteExists(compte.User))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompte", new { id = compte.User }, compte);
        }

        // DELETE: api/Comptes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompte(string id)
        {
            if (_context.Comptes == null)
            {
                return NotFound();
            }
            var compte = await _context.Comptes.FindAsync(id);
            if (compte == null)
            {
                return NotFound();
            }

            _context.Comptes.Remove(compte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompteExists(string id)
        {
            return (_context.Comptes?.Any(e => e.User == id)).GetValueOrDefault();
        }
    }
}
