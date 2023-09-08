using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.Data;
using StoreGame_WebAPI.DTO;
using StoreGame_WebAPI.entities;
using StoreGame_WebAPI.Entities;

namespace StoreGame_WebAPI.Controllers
{
    [Route("api/GameStore/Wishlists")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        private readonly GameContext _context;

        public WishlistsController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Wishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishlistsDTO>>> GetWishlist()
        {
            // Récupérer les wishlists et les jeux associés
            var wishlistDTOs = await _context.Wishlist
                .Include(w => w.Jeux)  // Charger les jeux associés
                .Select(w => new WishlistsDTO
                {
                    IdWishlist = w.Id,
                    User = w.User,
                    NomsJeux = w.Jeux.Select(j => j.NomJeu).ToList()  // Sélectionner les noms des jeux
                })
                .ToListAsync();

            // Vérifier si aucune wishlist n'a été trouvée
            if (wishlistDTOs == null || wishlistDTOs.Count == 0)
            {
                return NotFound("Aucune wishlist trouvée");
            }

            return Ok(wishlistDTOs);
        }

        // GET: api/Wishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(int id)
        {
          if (_context.Wishlist == null)
          {
              return NotFound();
          }
            var wishlist = await _context.Wishlist.FindAsync(id);

            if (wishlist == null)
            {
                return NotFound();
            }

            return wishlist;
        }

        // PUT: api/Wishlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(int id, Wishlist wishlist)
        {
            if (id != wishlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(id))
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

        // POST: api/Wishlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(Wishlist wishlist)
        {
            // Trouver la wishlist existante pour cet utilisateur
            var existingWishlist = await _context.Wishlist
                                                 .Include(w => w.Jeux)
                                                 .FirstOrDefaultAsync(w => w.User == wishlist.User);

            if (existingWishlist != null)
            {
                // Ajouter les nouveaux jeux à la wishlist existante
                foreach (var jeu in wishlist.Jeux)
                {
                    // Chercher le jeu existant dans la base de données
                    var existingJeu = await _context.Jeux.FindAsync(jeu.IdJeu);
                    if (existingJeu != null)
                    {
                        // Ajouter le jeu existant à la wishlist
                        existingWishlist.Jeux.Add(existingJeu);
                    }
                }

                _context.Entry(existingWishlist).State = EntityState.Modified;
            }
            else
            {
                // Si la wishlist n'existe pas encore, vous pouvez ajouter la nouvelle wishlist
                // Assurez-vous que les jeux existent déjà dans la base de données ou ajoutez-les avant de faire ça.
                _context.Wishlist.Add(wishlist);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWishlist", new { id = wishlist.Id }, wishlist);
        }


        [HttpGet("gameNameById/{id}")]
        public async Task<ActionResult<string>> GetGameNameById(int id)
        {
            try
            {
                var jeu = await _context.Jeux.FindAsync(id);

                if (jeu == null)
                {
                    return NotFound(); // Retournez un code 404 si le jeu n'est pas trouvé.
                }

                return Ok(jeu.NomJeu);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite : {ex.Message}");
            }
        }


        // DELETE: api/Wishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            if (_context.Wishlist == null)
            {
                return NotFound();
            }
            var wishlist = await _context.Wishlist.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }

            _context.Wishlist.Remove(wishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("favoriteGameStats")]
        public async Task<ActionResult<IEnumerable<FavoriteGameStats>>> GetFavoriteGameStats()
        {
            try
            {
                var results = await _context.FavoriteGameStats.FromSqlRaw("EXEC GetFavoriteGameStats").ToListAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite : {ex.Message}");
            }
        }


        private bool WishlistExists(int id)
        {
            return (_context.Wishlist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
