using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.Data;
using StoreGame_WebAPI.DTO;
using StoreGame_WebAPI.DTO.classIntermediaire;
using StoreGame_WebAPI.entities;
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

          var gamereviews = await _context.GameReviews
                .Include(gr=> gr.Jeu)
                .Select(gr => new GameReviewDTO
                {
                    User = gr.User,
                    NomJeu = gr.Jeu.NomJeu, 
                    Commentaire = gr.Commentaire,
                    Note = gr.Note
                })
                .ToListAsync();

            if (gamereviews == null || gamereviews.Count == 0)
            {
                return NotFound("Aucune revu de jeu");
            }



            return Ok(gamereviews);
        }

        // GET: api/GameReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameReview>> GetGameReview(int id)
        {
          if (_context.GameReviews == null)
          {
              return NotFound();
          }
            var gameReview = await _context.GameReviews
                .Include(gr => gr.Jeu) 
                .FirstOrDefaultAsync(gr => gr.IdReview == id);

            if (gameReview == null)
            {
                return NotFound("Il n'y a aucun revu correspondant à l'id =>"+id);
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
        public async Task<ActionResult<IEnumerable<GameReviewsWithGameNameDTO>>> GetGameReviewByGame(int id)
        {
            var gameReviews = await _context.GameReviews
                .FromSqlRaw("GetGameReviewsByGameId @idJeu", new SqlParameter("@idJeu", id))
                .ToListAsync();

            if (gameReviews == null || gameReviews.Count == 0)
            {
                return NotFound("Aucun gameReview pour le jeu " + id);
            }

            var gameReviewDTOs = new List<GameReviewDTO>();

            foreach (var gameReview in gameReviews) {
                var review = new GameReviewDTO
                {
                    User = gameReview.User,
                    NomJeu = _context.Jeux.Find(id).NomJeu,
                    Commentaire = gameReview.Commentaire,
                    Note = gameReview.Note
                };
                gameReviewDTOs.Add(review);
            }

            return Ok(gameReviewDTOs);
        }

        //GET: api/GameReviews/Average/5
        [HttpGet("Average/{id}")]
        public IActionResult GetAverageReview(int id)
        {
            var averageScore = _context.Set<AverageScoreResult>()
                .FromSqlRaw("GetGameReviewsAvgByGame @idJeu", new SqlParameter("@idJeu", id))
                .AsEnumerable()
                .SingleOrDefault();

            if (averageScore == null)
            {
                return NotFound("Aucun gameReview pour le jeu " + id);
            }

            GameReviewAverageDTO game = new GameReviewAverageDTO
            {
                MoyenneNote = Convert.ToDouble(averageScore.MoyenneNote),
                IdJeu = id,
                Nom = _context.Jeux.Find(id).NomJeu
            };

            return Ok(game);
        }

        //GET: api/GameReviews/Average
        [HttpGet("Average")]
        public async Task<ActionResult<List<GameReviewAverageDTO>>> GetAverageReviewForEachGame()
        {
            var averageScorelist = await _context.Set<AverageReviewForEachGame>()
                .FromSqlRaw("GetAverageReviewForEachGame")
                .ToListAsync();

            if (averageScorelist == null || averageScorelist.Count == 0)
            {
                return NotFound("No game reviews found.");
            }


            var gameReviewDTOs = averageScorelist.Select(averageScore => new GameReviewAverageDTO
            {
                IdJeu = averageScore.IdJeu,
                MoyenneNote = Convert.ToDouble(averageScore.MoyenneNote),
                Nom = _context.Jeux.Find(averageScore.IdJeu).NomJeu 
            }).ToList();

            return Ok(gameReviewDTOs);
        }

  

        private bool GameReviewExists(int id)
        {
            return (_context.GameReviews?.Any(e => e.IdReview == id)).GetValueOrDefault();
        }



    }
}
