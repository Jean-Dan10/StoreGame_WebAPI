using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.entities;
using StoreGame_WebAPI.Entities;

namespace StoreGame_WebAPI.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Jeu> Jeux { get; set; }

        public DbSet<GameReview> GameReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // pour ajouter une contrainte unique de user et jeu. Donc seulement 1 review par jeu par user
            modelBuilder.Entity<GameReview>()
                .HasIndex(gr => new { gr.User, gr.IdJeu }) 
                .IsUnique();

            InitData(modelBuilder);
             
        }

        private void InitData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compte>().HasData(
                new Compte { User = "admin", Password = "123", ProfileName = "Orignal" },
                new Compte { User = "Tyzral", Password = "123", ProfileName = "Tyzral" },
                new Compte { User = "Grimworld", Password = "123", ProfileName = "Grimworld" },
                new Compte { User = "THEFRIEND", Password = "123", ProfileName = "ami" }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { IdClient = 1, Nom = "admin", Prenom = "admin", AdressePhysique = "", AdresseCourriel = "", User = "admin" },
                new Client { IdClient = 2, Nom = "Beaudry", Prenom = "Simon", AdressePhysique = "5150 rues des ormes", AdresseCourriel = "Tyzral@gmail.com", User = "Tyzral" },
                new Client { IdClient = 3, Nom = "Mercier", Prenom = "Francis", AdressePhysique = "221B Baker Street", AdresseCourriel = "Grimworld@gmail.com", User = "Grimworld" },
                new Client { IdClient = 4, Nom = "Ami", Prenom = "Ami", AdressePhysique = "50 rue l'Amitié", AdresseCourriel = "ami@gmail.com", User = "THEFRIEND" }
            );

            modelBuilder.Entity<Genre>().HasData(
                 new Genre { IdGenre = 1, Name = "Action-aventure" },
                 new Genre { IdGenre = 2, Name = "Plateforme" },
                 new Genre { IdGenre = 3, Name = "RPG" },
                 new Genre { IdGenre = 4, Name = "Sandbox" },
                 new Genre { IdGenre = 5, Name = "FPS" },
                 new Genre { IdGenre = 6, Name = "Strategy" },
                 new Genre { IdGenre = 7, Name = "Sports" },
                 new Genre { IdGenre = 8, Name = "Simulation" },
                 new Genre { IdGenre = 9, Name = "Puzzle" },
                 new Genre { IdGenre = 10, Name = "Horror" }
             );

        }
    }


}