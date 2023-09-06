using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.Data;
using StoreGame_WebAPI.Entities;

namespace StoreGame_WebAPI.Controllers
{
    [Route("api/GameStore/GameReviews")]
    [ApiController]
    public class GameReviewsController : ControllerBase
    {
        private readonly GameContext _context;

        public GameReviewsController(GameContext context)
        {
            _context = context;
        }

        // GET: api/GameReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameReview>>> GetGameReviews()
        {
          if (_context.GameReviews == null)
          {
              return NotFound();
          }
            return await _context.GameReviews.ToListAsync();
        }

        // GET: api/GameReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameReview>> GetGameReview(int id)
        {
          if (_context.GameReviews == null)
          {
              return NotFound();
          }
            var gameReview = await _context.GameReviews.FindAsync(id);

            if (gameReview == null)
            {
                return NotFound();
            }

            return gameReview;
        }

        // PUT: api/GameReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameReview(int id, GameReview gameReview)
        {
            if (id != gameReview.IdReview)
            {
                return BadRequest();
            }

            _context.Entry(gameReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameReviewExists(id))
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

        // POST: api/GameReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameReview>> PostGameReview(GameReview gameReview)
        {
          if (_context.GameReviews == null)
          {
              return Problem("Entity set 'GameContext.GameReviews'  is null.");
          }
            _context.GameReviews.Add(gameReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameReview", new { id = gameReview.IdReview }, gameReview);
        }

        // DELETE: api/GameReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameReview(int id)
        {
            if (_context.GameReviews == null)
            {
                return NotFound();
            }
            var gameReview = await _context.GameReviews.FindAsync(id);
            if (gameReview == null)
            {
                return NotFound();
            }

            _context.GameReviews.Remove(gameReview);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //GET: api/GameReviews/Game/5

        [HttpGet("Game/{id}")]
        public async Task<ActionResult<IEnumerable<object>>> GetGameReviewByGame(int id)
        {

           

            if (_context.GameReviews == null)
            {
                return NotFound();
            }
            var gameReviews = await _context.GameReviews
                .FromSqlRaw("GetGameReviewsByGameId @idJeu", new SqlParameter("@idJeu", id))
               .ToListAsync();

            foreach( var gameReview in gameReviews)
            {
                _context.Entry(gameReview)
                    .Reference(r => r.Jeu)
                    .Load();
            }
               

            if (gameReviews == null || gameReviews.Count == 0)
            {
                return NotFound("Aucun gameReview pour le jeu"+ id);
            }

            var result = gameReviews.Select(r => new
            {
                r.IdReview,
                r.User,
                r.Commentaire,
                r.Note,
                NomJeu = r.Jeu?.NomJeu 
            }).ToList();

            return result;
        }

        private bool GameReviewExists(int id)
        {
            return (_context.GameReviews?.Any(e => e.IdReview == id)).GetValueOrDefault();
        }



    }
}
