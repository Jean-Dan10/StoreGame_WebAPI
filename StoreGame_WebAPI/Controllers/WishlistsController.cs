using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.Data;
using StoreGame_WebAPI.DTO;
using StoreGame_WebAPI.entities;
using StoreGame_WebAPI.Entities;
using StoreGame_WebAPI.Service;

namespace StoreGame_WebAPI.Controllers
{
    [Route("api/GameStore/Wishlists")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        private readonly GameContext _context;
        private readonly WishlistService _wishlistService;
        public WishlistsController(GameContext context, WishlistService wishlistService)
        {
            _context = context;
            _wishlistService = wishlistService;
        }



        // GET: api/Wishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishlistsDTO>>> GetWishlists()
        {
            var wishlistDTOs = await _wishlistService.GetAllWishlists();

            if (wishlistDTOs == null || !wishlistDTOs.Any())
            {
                return NotFound("Aucune wishlist trouvée.");
            }

            return Ok(wishlistDTOs);
        }

        // GET: api/Wishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(int id)
        {
          if (_context.Wishlists == null)
          {
              return NotFound();
          }
            var wishlist = await _context.Wishlists.FindAsync(id);

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
            var result = await _wishlistService.AddWishlist(wishlist);
            if (result == null)
            {
                return BadRequest("L'entiter est null");
            }
            return CreatedAtAction("GetWishlist", new { id = wishlist.Id }, wishlist);
            
        }

        // DELETE: api/Wishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            try
            {
                var message = await _wishlistService.DeleteWishlist(id);
                return Ok(message); // Return le message de succes
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Return un message d'erreur que la wishlist n'a pas ete trouver
            }
        }





        //fonctionnel, version final
        [HttpPost("AddGamesToWishlists")]
        public async Task<IActionResult> AddGamesToWishlists([FromBody] requeteWishlistDTO request)
        {
            var result = await _wishlistService.AddGamesToWishlistsService(request);

            if (result == "Wishlist not found")
            {
                return NotFound(result);
            }

            return Ok(result);
        }


        //non fonctionnel
        [HttpGet("GetAllGamesInWishlistWithInfos/{wishlistId}")]
        public async Task<IActionResult> GetAllGamesInWishlistWithInfos(int wishlistId)
        {
            try
            {
                var (wishlistOwner, gamesInfo) = await _wishlistService.GetAllGamesInWishlistWithInfosAsync(wishlistId);

                if (wishlistOwner == null || gamesInfo == null)
                {
                    return NotFound("Wishlist not found");
                }

                return Ok(new { WishlistOwner = wishlistOwner.User, GamesInfo = gamesInfo });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }




        //fonctionnel
        [HttpDelete("DeleteGameFromWishlist/{wishlistId}/{jeuId}")]
        public async Task<IActionResult> DeleteGameFromWishlist(int wishlistId, int jeuId)
        {
            var responseMessage = await _wishlistService.RemoveGameFromWishlist(wishlistId, jeuId);

            if (responseMessage.Contains("n'existe pas") || responseMessage.Contains("n'y a jamais été ajouté"))
            {
                return NotFound(responseMessage);
            }

            return Ok(responseMessage);
        }

        [HttpGet("pourcentage/{jeuId}")]
        public async Task<IActionResult> GetGameOccurrencePercentage(int jeuId)
        {
            var (jeuName, percentage, timesInWishlists) = await _wishlistService.GetGameOccurrencePercentage(jeuId);

            if (jeuName == null)
            {
                return NotFound("Jeu not found");
            }

            return Ok(new { JeuNom = jeuName, Percentage = percentage, TimesInWishlists = timesInWishlists });
        }






        private bool WishlistExists(int id)
        {
            return (_context.Wishlists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
