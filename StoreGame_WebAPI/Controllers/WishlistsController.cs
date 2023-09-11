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
        public async Task<ActionResult<IEnumerable<WishlistsDTO>>> GetWishlists()
        {
            var wishlistDTOs = await _context.Wishlists
    .Include(w => w.JeuWishlists) // Include the jeuWishlists table
        .ThenInclude(jw => jw.Jeu) // Then include the Jeu
    .Select(w => new WishlistsDTO
    {
        IdWishlist = w.Id,
        User = w.User,
        NomsJeux = w.JeuWishlists.Select(jw => jw.Jeu.NomJeu).ToList() // Fetch Jeu names through jeuWishlists
    })
    .ToListAsync();

            if (wishlistDTOs == null || wishlistDTOs.Count == 0)
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
          if (_context.Wishlists == null)
          {
              return Problem("Entity set 'GameContext.Wishlists'  is null.");
          }
            _context.Wishlists.Add(wishlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWishlist", new { id = wishlist.Id }, wishlist);
        }

        // DELETE: api/Wishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
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

            _context.Wishlists.Remove(wishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       

        //fonctionnel, version avec deja dedans et non (pas de verif si donner non existante)
        [HttpPost("AddGamesToWishlist")]
        public async Task<IActionResult> AddGamesToWishlist([FromBody] requeteWishlistDTO request)
        {
            int wishlistId = request.WishlistId;
            List<int> gameIds = request.GameIds;

            // recherche et verifie si la wishlist est presente
            var wishlist = await _context.Wishlists.FindAsync(wishlistId);
            if (wishlist == null)
            {
                return NotFound("Wishlist not found");
            }

            // recherche et verifie sur le jeux est present
            var games = await _context.Jeux.Where(g => gameIds.Contains(g.IdJeu)).ToListAsync();
            if (games.Count != gameIds.Count)
            {
                return NotFound("One or more games not found");
            }

            // Check for existing entries
            var existingEntries = await _context.jeuWishlists
                .Where(jw => jw.WishlistsId == wishlistId && gameIds.Contains(jw.JeuxIdJeu))
                .Select(jw => jw.JeuxIdJeu)
                .ToListAsync();

            // Calculate new and already added game IDs
            var newGameIds = gameIds.Except(existingEntries).ToList();
            var alreadyAddedGameIds = gameIds.Intersect(existingEntries).ToList();

            // Add new entries
            foreach (var gameId in newGameIds)
            {
                var jeuWishlist = new JeuWishlist
                {
                    JeuxIdJeu = gameId,
                    WishlistsId = wishlistId
                };

                _context.jeuWishlists.Add(jeuWishlist);
            }
            await _context.SaveChangesAsync();

            if (alreadyAddedGameIds.Any())
            {
                return Ok($"Les jeux avec les ID {string.Join(", ", newGameIds)} ont été ajoutés. Les jeux avec les ID {string.Join(", ", alreadyAddedGameIds)} étaient déjà dans la liste de souhaits et n'ont pas été ajoutés à nouveau.");
            }

            return Ok($"Les jeux avec les ID {string.Join(", ", newGameIds)} ont été ajoutés à la liste de souhaits.");
        }


        //fonctionnel, version final
        [HttpPost("AddGamesToWishlists")]
        public async Task<IActionResult> AddGamesToWishlists([FromBody] requeteWishlistDTO request)
        {
            int wishlistId = request.WishlistId;
            List<int> gameIds = request.GameIds;

            // Recherche et vérifie si la wishlist est présente
            var wishlist = await _context.Wishlists.FindAsync(wishlistId);
            if (wishlist == null)
            {
                return NotFound("Wishlist not found");
            }

            // Recherche et vérifie si le jeu est présent
            var existingGames = await _context.Jeux.Where(g => gameIds.Contains(g.IdJeu)).ToListAsync();
            var notFoundGameIds = gameIds.Except(existingGames.Select(g => g.IdJeu)).ToList();

            // verifie si les donner entrer sont belle et biens present
            var existingEntries = await _context.jeuWishlists
                .Where(jw => jw.WishlistsId == wishlistId && gameIds.Contains(jw.JeuxIdJeu))
                .Select(jw => jw.JeuxIdJeu)
                .ToListAsync();

            // regarde la requete et verifie si la nouvelle requete n'est pas deja presente dans celle deja dans la database
            var newGameIds = existingGames.Select(g => g.IdJeu).Except(existingEntries).ToList();
            var alreadyAddedGameIds = existingGames.Select(g => g.IdJeu).Intersect(existingEntries).ToList();

            // ajouter les nouvelles donners
            foreach (var gameId in newGameIds)
            {
                var jeuWishlist = new JeuWishlist
                {
                    JeuxIdJeu = gameId,
                    WishlistsId = wishlistId
                };
                _context.jeuWishlists.Add(jeuWishlist);
            }
            await _context.SaveChangesAsync();

            List<string> messages = new List<string>();

            if (newGameIds.Any())
            {
                messages.Add($"Les jeux avec les ID {string.Join(", ", newGameIds)} ont été ajoutés.");
            }

            if (alreadyAddedGameIds.Any())
            {
                messages.Add($"Les jeux avec les ID {string.Join(", ", alreadyAddedGameIds)} étaient déjà dans la liste de souhaits et n'ont pas été ajoutés à nouveau.");
            }

            if (notFoundGameIds.Any())
            {
                messages.Add($"Les jeux avec les ID {string.Join(", ", notFoundGameIds)} n'ont pas été trouvés et n'ont pas été ajoutés.");
            }

            return Ok(string.Join(" ", messages));
        }

        [HttpGet("GetCompletionRate/{wishlistId}")]
        public async Task<IActionResult> GetWishlistCompletionRate(int wishlistId)
        {
            // Déclare une variable pour stocker le taux de complétion
            float completionRate = 0;
            string jeuNom = ""; // Ajouté pour stocker le nom du jeu

            // Crée une nouvelle connexion SQL en utilisant la chaîne de connexion du contexte
            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    // Définit la commande pour exécuter la procédure stockée
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "CalculateWishlistCompletionRates";

                    // Ajoute les paramètres nécessaires
                    var wishlistIdParam = new SqlParameter("@WishlistId", wishlistId);
                    var completionRateParam = new SqlParameter("@CompletionRate", SqlDbType.Float)
                    {
                        Direction = ParameterDirection.Output
                    };
                    var jeu = await _context.Jeux.FindAsync(wishlistId);
                    if (jeu != null)
                    {
                        jeuNom = jeu.NomJeu;
                    }

                    command.Parameters.Add(wishlistIdParam);
                    command.Parameters.Add(completionRateParam);

                    // Exécute la commande
                    await command.ExecuteNonQueryAsync();

                    // Récupère le taux de complétion depuis le paramètre de sortie
                    double temp = Convert.ToDouble(completionRateParam.Value);
                    completionRate = (float)temp;
                }
            }



            return Ok($"Le taux de complétion pour le jeu {jeuNom} est de {completionRate}%.");

        }


        //fonctionnel
        [HttpGet("GetAllGamesInWishlistWithInfos/{wishlistId}")]
        public async Task<IActionResult> GetAllGamesInWishlistWithInfos(int wishlistId)
        {
            // Récupérer le nombre total de jeux dans toutes les wishlists
            int totalGamesInAllWishlists = await _context.jeuWishlists.CountAsync();

            // Votre code existant pour récupérer la wishlist spécifique
            var wishlistExists = await _context.Wishlist.AnyAsync(w => w.Id == wishlistId);
            if (wishlistExists == null)
            {
                return NotFound("Wishlist not found");
            }

            List<JeuWishlistInfoDTO> jeuxInfo = new List<JeuWishlistInfoDTO>();

            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAllGamesInWishlistWithInfo";

                    var wishlistIdParam = new SqlParameter("@WishlistId", wishlistId);
                    command.Parameters.Add(wishlistIdParam);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            // Calculer le taux de complétion
                            float completionRate = (reader.GetInt32(1) / (float)totalGamesInAllWishlists) * 100;

                            jeuxInfo.Add(new JeuWishlistInfoDTO
                            {
                                NomJeu = reader.GetString(0),
                                CompletionRate = completionRate,
                                TimesInWishlists = reader.GetInt32(1)
                            });
                        }
                    }
                }
            }

            return Ok(jeuxInfo);
        }

        //fonctionnel
        [HttpDelete("DeleteGameFromWishlist/{wishlistId}/{jeuId}")]
        public async Task<IActionResult> DeleteGameFromWishlist(int wishlistId, int jeuId)
        {
            // Vérifiez si la wishlist existe
            var wishlistExists = await _context.Wishlist.FindAsync(wishlistId);
            if (wishlistExists == null)
            {
                return NotFound("Le compte n'existe pas.");
            }

            // Vérifiez si le jeu est déjà dans la wishlist
            var gameInWishlist = await _context.jeuWishlists
                                               .Where(jw => jw.WishlistsId == wishlistId && jw.JeuxIdJeu == jeuId)
                                               .FirstOrDefaultAsync();

            if (gameInWishlist == null)
            {
                return NotFound("Le jeu a déjà été supprimé de la wishlist ou n'y a jamais été ajouté.");
            }

            // Suppression du jeu
            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteGameFromWishlist";

                    command.Parameters.Add(new SqlParameter("@WishlistId", wishlistId));
                    command.Parameters.Add(new SqlParameter("@JeuId", jeuId));

                    await command.ExecuteNonQueryAsync();
                }
            }

            return Ok("Jeu supprimé de la wishlist.");
        }

        [HttpGet("pourcentage/{jeuId}")]
        public async Task<IActionResult> GetGameOccurrencePercentage(int jeuId)
        {
            double percentage;

            // Récupérer le nom du jeu à partir de la base de données
            var jeu = await _context.Jeux.FindAsync(jeuId);
            if (jeu == null)
            {
                return NotFound("Jeu not found");
            }

            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "affichePourcentagePourJeuWishlistParId";

                    // Paramètres
                    var jeuIdParam = new SqlParameter("@JeuId", jeuId);
                    var percentageParam = new SqlParameter
                    {
                        ParameterName = "@Percentage",
                        SqlDbType = SqlDbType.Float,
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(jeuIdParam);
                    command.Parameters.Add(percentageParam);

                    // Exécution
                    await command.ExecuteNonQueryAsync();

                    // Récupération de la valeur du pourcentage
                    percentage = (double)percentageParam.Value;
                }
            }

            // Retourner le nom du jeu et le pourcentage
            return Ok(new { JeuNom = jeu.NomJeu, Percentage = percentage });
        }






        private bool WishlistExists(int id)
        {
            return (_context.Wishlists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
