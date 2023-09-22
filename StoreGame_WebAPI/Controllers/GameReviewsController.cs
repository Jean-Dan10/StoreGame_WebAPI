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
using StoreGame_WebAPI.Service;

namespace StoreGame_WebAPI.Controllers
{
    [Route("api/GameStore/GameReviews")]
    [ApiController]
    public class GameReviewsController : ControllerBase
    {
        
        private GameReviewService _GRService;

        public GameReviewsController(GameContext context, GameReviewService gameReviewService)
        {
            
            _GRService = gameReviewService;
        }

        // GET: api/GameReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameReviewDTO>>> GetGameReviews()
        {


            var gamereviews = await _GRService.GetALLGameReviews();
         

            if (gamereviews == null || !gamereviews.Any())
            {
                return NotFound("Aucune revu de jeu");
            }



            return Ok(gamereviews);
        }

        // GET: api/GameReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameReviewDTO>> GetGameReview(int id)
        {
            
       
            var gameReview = await _GRService.GetGameReview(id);

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

            var check = await _GRService.UpdateGameReview(id, gameReview);

                if (check)
                {
                return NoContent();
                }
                else
                {
                return NotFound("Aucune revu de jeu avec le id suivant : " + id); ;
                }
            }

          
        

        // POST: api/GameReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameReview>> PostGameReview(GameReview gameReview)
        {
         

            if (gameReview.Note < 0 || gameReview.Note > 5)
            {
                return Problem("La note doit être comprise entre 0 et 5");
            }

            await _GRService.AddGameReview(gameReview);

            return CreatedAtAction("GetGameReview", new { id = gameReview.IdReview }, gameReview);
        }

        // DELETE: api/GameReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameReview(int id)
        {
            if (_GRService.GameReviewExists(id))
            {
                return NotFound("Aucune revu de jeu avec le id suivant : " + id);
            }

            var check = await _GRService.DeleteGameReview(id);
            if (!check)
            {
                return Problem("Une erreur est survenue lors la suppression de la revu avec le id suivant : " + id);
            }else
            {
                return Ok("La revu de jeu avec le ID :" + id + " à été supprimé avec succès");
            }          

            
        }


        //GET: api/GameStore/GameReviews/game/5
        // retrouver les gamereview pour un id de jeu spécifique

        [HttpGet("game/{id}")]
        public async Task<IActionResult> GetGameReviewByGame(int gameId)
        {
            if (!_GRService.GameReviewExists(gameId))
            {
                return NotFound("Aucune jeu n'existe pour ce id: " + gameId);
            }

            var gameReviewDTOs = await _GRService.GetGameReviewsByGame(gameId);

            if (gameReviewDTOs == null)
            {
                return NotFound("Aucun gameReview pour le jeu " + gameId);
            }

            if (!gameReviewDTOs.Any())
            {
                return NotFound("Aucun gameReview pour le jeu " + gameId);
            }

            return Ok(gameReviewDTOs);
        }

        //GET: api/GameReviews/Average/5
        //retrouver la moyenne pour un jeu specifique
        [HttpGet("Average/{id}")]
        public async Task<IActionResult> GetAverageReview(int gameId)

        {
            
            if (!_GRService.JeuExists(gameId)){
                return NotFound("Aucune jeu n'existe pour ce id: " + gameId);

            }

            var gameReviewDTOs = await _GRService.GetGameReviewsByGame(gameId);

            if (gameReviewDTOs == null)
            {
                return NotFound("Aucun gameReview pour le jeu " + gameId);
            }

            if (!gameReviewDTOs.Any())
            {
                return NotFound("Aucun gameReview pour le jeu " + gameId);
            }
                                

            return Ok(_GRService.GetAverageReview(gameId));
        }

        //GET: api/GameReviews/Average
        //toutes les moyenne de tous les jeux
        [HttpGet("Average")]
        public async Task<ActionResult<IEnumerable<GameReviewAverageDTO>>> GetAverageReviewForEachGame()
        {

            var gameReviewDTOs = await _GRService.GetAverageReviewForEachGame();  

            if (gameReviewDTOs == null || !gameReviewDTOs.Any())
            {
                return NotFound("aucune revu de jeu trouvé");
            }
                     
            return Ok(gameReviewDTOs);
        }

  




    }
}
