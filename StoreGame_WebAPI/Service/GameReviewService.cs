using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.Data;
using StoreGame_WebAPI.DTO;
using StoreGame_WebAPI.DTO.classIntermediaire;
using StoreGame_WebAPI.Entities;

namespace StoreGame_WebAPI.Service
{
    public class GameReviewService
    {

        private readonly GameContext _context;

        public GameReviewService(GameContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<GameReviewDTO>> GetALLGameReviews()
        {
            var gamereviews = await _context.GameReviews
                .Include(gr => gr.Jeu)
                .Select(gr => new GameReviewDTO
                {
                    IdReview = gr.IdReview,
                    User = gr.User,
                    NomJeu = gr.Jeu.NomJeu,
                    Commentaire = gr.Commentaire,
                    Note = gr.Note
                })
                .ToListAsync();

            return gamereviews;
        }


        public async Task<GameReviewDTO> GetGameReview(int id)
        {
           
            var gameReview = await _context.GameReviews
                .Include(gr => gr.Jeu)
                    .Select(gr => new GameReviewDTO
                    {
                        IdReview = gr.IdReview,
                        User = gr.User,
                        NomJeu = gr.Jeu.NomJeu,
                        Commentaire = gr.Commentaire,
                        Note = gr.Note
                    })
                .FirstOrDefaultAsync(gr => gr.IdReview == id);

         
            return gameReview;
        }


        
        public async Task<bool> UpdateGameReview(int id, GameReview gameReview)
        {
          

            _context.Entry(gameReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameReviewExists(id))
                {
                    return false;
                }else
                {
                    throw;
                }
               
            }

            return true;
        }

        public async Task<bool> AddGameReview(GameReview gameReview)
        {

           
            _context.GameReviews.Add(gameReview);
            await _context.SaveChangesAsync();

            return true;
        }

   
       
        public async Task<bool> DeleteGameReview(int id)
        {
            

            var gameReview = await _context.GameReviews.FindAsync(id);
            
            _context.GameReviews.Remove(gameReview);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GameReviewDTO>> GetGameReviewsByGame(int id)
        {
            if (!_context.Jeux.Any(j => j.IdJeu == id))
            {
                
                return null;
            }

            var gameReviews = await _context.GameReviews
                .FromSqlRaw("GetGameReviewsByGameId @idJeu", new SqlParameter("@idJeu", id))
                .ToListAsync();

            if (gameReviews == null || gameReviews.Count == 0)
            {
                return null;
            }

            var gameReviewDTOs = gameReviews.Select(gameReview => new GameReviewDTO
            {
                IdReview= gameReview.IdReview,
                User = gameReview.User,
                NomJeu = _context.Jeux.Find(id).NomJeu,
                Commentaire = gameReview.Commentaire,
                Note = gameReview.Note
            });

            return gameReviewDTOs;
        }

   
       
        public async Task<GameReviewAverageDTO> GetAverageReview(int gameId)

        {
                              
            var averageScore = _context.Set<AverageScoreResult>()
                .FromSqlRaw("GetGameReviewsAvgByGame @idJeu", new SqlParameter("@idJeu", gameId))
                .AsEnumerable()
                .SingleOrDefault();

          
            GameReviewAverageDTO game = new GameReviewAverageDTO
            {
                MoyenneNote = Convert.ToDouble(averageScore.MoyenneNote),
                IdJeu = gameId,
                Nom = _context.Jeux.Find(gameId).NomJeu
            };

            return game;
        }

       
        public async Task<IEnumerable<GameReviewAverageDTO>> GetAverageReviewForEachGame()
        {
            var averageScorelist = await _context.Set<AverageReviewForEachGame>()
                .FromSqlRaw("GetAverageReviewForEachGame")
                .ToListAsync();

         
            var gameReviewDTOs = averageScorelist.Select(averageScore => new GameReviewAverageDTO
            {
                IdJeu = averageScore.IdJeu,
                MoyenneNote = Convert.ToDouble(averageScore.MoyenneNote),
                Nom = _context.Jeux.Find(averageScore.IdJeu).NomJeu
            }).ToList();

            return gameReviewDTOs;
        }



        public bool GameReviewExists(int id)
        {
            return (_context.GameReviews?.Any(e => e.IdReview == id)).GetValueOrDefault();
        }

        public bool JeuExists(int id)
        {
            return (_context.Jeux?.Any(e => e.IdJeu == id)).GetValueOrDefault();
        }

        public bool checkDuplicate(string user, int gameId)
        {
            return _context.GameReviews.Any(gr => gr.User == user && gr.IdJeu == gameId);


        }


    }




}
