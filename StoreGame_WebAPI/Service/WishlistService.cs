using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.Data;
using StoreGame_WebAPI.DTO;
using StoreGame_WebAPI.DTO.classIntermediaire;
using StoreGame_WebAPI.entities;
using StoreGame_WebAPI.Entities;
using System.Data;

namespace StoreGame_WebAPI.Service
    {
        public class WishlistService
        {
            private readonly GameContext _context;

            public WishlistService(GameContext context)
            {
                _context = context;
            }





            public async Task<IEnumerable<WishlistsDTO>> GetAllWishlists()
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

                return wishlistDTOs;
            }

            public async Task<WishlistsDTO> GetWishlist(int id)
            {
                var wishlist = await _context.Wishlists
                    .Include(w => w.JeuWishlists)
                    .ThenInclude(jw => jw.Jeu)
                    .Where(w => w.Id == id)
                    .Select(w => new WishlistsDTO
                    {
                        IdWishlist = w.Id,
                        User = w.User,
                        NomsJeux = w.JeuWishlists.Select(jw => jw.Jeu.NomJeu).ToList()
                    })
                    .FirstOrDefaultAsync();

                return wishlist;
            }

            // Example: Add a method to add a new wishlist
            public async Task<Wishlist> AddWishlist(Wishlist wishlist)
            {
                _context.Wishlists.Add(wishlist);
                await _context.SaveChangesAsync();
                return wishlist;
            }


        // Example: Delete a wishlist
        public async Task<string> DeleteWishlist(int id)
        {
            var wishlist = await _context.Wishlists.FindAsync(id);
            if (wishlist == null)
            {
                throw new Exception($"Wishlist avec l' ID {id} non trouver.");
            }

            _context.Wishlists.Remove(wishlist);
            await _context.SaveChangesAsync();

            return $"Wishlist avec l' ID {id} a belle et bien ete supprimer.";
        }


        public async Task<(string jeuName, double percentage, int timesInWishlists)> GetGameOccurrencePercentage(int jeuId)
        {
            double percentage;
            int timesInWishlists;

            // Récupérer le nom du jeu à partir de la base de données
            var jeu = await _context.Jeux.FindAsync(jeuId);
            if (jeu == null)
            {
                return (null, 0, 0);
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

                    // Recuperation  de la valeur du nombre de fois a ete ajouter a la wishlist
                    timesInWishlists = await _context.jeuWishlists.CountAsync(jw => jw.JeuxIdJeu == jeuId);
                }
            }

            return (jeu.NomJeu, percentage, timesInWishlists);
        }




        // Add a game to a wishlist
        public async Task<string> AddGamesToWishlistsService(requeteWishlistDTO request)
        {
            int wishlistId = request.WishlistId;
            List<int> gameIds = request.GameIds;

            var wishlist = await _context.Wishlists.FindAsync(wishlistId);
            if (wishlist == null)
            {
                return "Wishlist non trouver";
            }

            var existingGames = await _context.Jeux.Where(g => gameIds.Contains(g.IdJeu)).ToListAsync();
            var notFoundGameIds = gameIds.Except(existingGames.Select(g => g.IdJeu)).ToList();

            var existingEntries = await _context.jeuWishlists
                .Where(jw => jw.WishlistsId == wishlistId && gameIds.Contains(jw.JeuxIdJeu))
                .Select(jw => jw.JeuxIdJeu)
                .ToListAsync();

            var newGameIds = existingGames.Select(g => g.IdJeu).Except(existingEntries).ToList();
            var alreadyAddedGameIds = existingGames.Select(g => g.IdJeu).Intersect(existingEntries).ToList();

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

            return string.Join(" ", messages);
        }


        // Remove a game from a wishlist
        public async Task<string> RemoveGameFromWishlist(int wishlistId, int jeuId)
        {
            var wishlistExists = await _context.Wishlist.FindAsync(wishlistId);
            if (wishlistExists == null)
            {
                return "Le compte n'existe pas.";
            }

            var gameInWishlist = await _context.jeuWishlists
                                               .Where(jw => jw.WishlistsId == wishlistId && jw.JeuxIdJeu == jeuId)
                                               .FirstOrDefaultAsync();

            if (gameInWishlist == null)
            {
                return "Le jeu a déjà été supprimé de la wishlist ou n'y a jamais été ajouté.";
            }

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

            return "Jeu supprimé de la wishlist.";
        }


        // Check if a game exists in a wishlist
        public async Task<bool> IsGameInWishlist(int wishlistId, int idJeu)
        {
            return await _context.jeuWishlists
                .AnyAsync(jw => jw.WishlistsId == wishlistId && jw.JeuxIdJeu == idJeu);
        }

        // Utility function to get all games in a wishlist
        // Inside WishlistService class
        public async Task<(Compte WishlistOwner, List<JeuWishlistInfoDTO> GamesInfo)> GetAllGamesInWishlistWithInfosAsync(int wishlistId)
        {
            int totalGamesInAllWishlists = await _context.jeuWishlists.CountAsync();
            var wishlistExists = await _context.Wishlist
                                              .Include(w => w.Compte)
                                              .Where(w => w.Id == wishlistId)
                                              .FirstOrDefaultAsync();

            if (wishlistExists == null)
            {
                return (null, null);
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

            return (wishlistExists.Compte, jeuxInfo);
        }

    }
}


