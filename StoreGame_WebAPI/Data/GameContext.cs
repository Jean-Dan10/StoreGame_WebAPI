﻿using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.DTO.classIntermediaire;
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

        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<FavoriteGameStats> FavoriteGameStats { get; set; }
        public DbSet<JeuWishlist> jeuWishlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // pour ajouter une contrainte unique de user et jeu. Donc seulement 1 review par jeu par user
            modelBuilder.Entity<GameReview>()
                .HasIndex(gr => new { gr.User, gr.IdJeu }) 
                .IsUnique();

            modelBuilder.Entity<JeuWishlist>()
         .HasKey(jw => new { jw.JeuxIdJeu, jw.WishlistsId });

            modelBuilder.Entity<JeuWishlist>()
                .HasOne(jw => jw.Jeu)
                .WithMany(j => j.JeuWishlists)
                .HasForeignKey(jw => jw.JeuxIdJeu);

            modelBuilder.Entity<JeuWishlist>()
                .HasOne(jw => jw.Wishlist)
                .WithMany(w => w.JeuWishlists)
                .HasForeignKey(jw => jw.WishlistsId);



            InitData(modelBuilder);

            modelBuilder.Entity<AverageScoreResult>().HasNoKey();

            modelBuilder.Entity<AverageReviewForEachGame>().HasNoKey();



        }

                private void InitData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compte>().HasData(
                new Compte { User = "admin", Password = "123", ProfileName = "Orignal" },
                new Compte { User = "Tyzral", Password = "123", ProfileName = "Tyzral" },
                new Compte { User = "Grimworld", Password = "123", ProfileName = "Grimworld" },
                new Compte { User = "THEFRIEND", Password = "123", ProfileName = "ami" },
                new Compte { User = "Test1", Password = "123", ProfileName = "LeTest1" },
                new Compte { User = "Test2", Password = "123", ProfileName = "LeTest2" }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { IdClient = 1, Nom = "admin", Prenom = "admin", AdressePhysique = "", AdresseCourriel = "", User = "admin" },
                new Client { IdClient = 2, Nom = "Beaudry", Prenom = "Simon", AdressePhysique = "5150 rues des ormes", AdresseCourriel = "Tyzral@gmail.com", User = "Tyzral" },
                new Client { IdClient = 3, Nom = "Mercier", Prenom = "Francis", AdressePhysique = "221B Baker Street", AdresseCourriel = "Grimworld@gmail.com", User = "Grimworld" },
                new Client { IdClient = 4, Nom = "Ami", Prenom = "Ami", AdressePhysique = "50 rue l'Amitié", AdresseCourriel = "ami@gmail.com", User = "THEFRIEND" },
                new Client { IdClient = 7, Nom = "Le", Prenom = "Test1", AdressePhysique = "44 rue l'Amitié", AdresseCourriel = "ami2@gmail.com", User = "Test1" },
                new Client { IdClient = 6, Nom = "Le", Prenom = "Test2", AdressePhysique = "45 rue l'Amitié", AdresseCourriel = "ami3@gmail.com", User = "Test2" }
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

            modelBuilder.Entity<Jeu>().HasData(
                new Jeu
                {
                    IdJeu = 1,
                    NomJeu = "Super Mario Odyssey",
                    Prix = 59.99,
                    IdGenre = 2,
                    Description = "Aidez Mario à sauver la princesse Peach dans une aventure trépidante à travers de nombreux royaumes.",
                    ImagePath = "/image/SMOdyssey.png"
                },
                new Jeu
                {
                    IdJeu = 2,
                    NomJeu = "The Legend of Zelda: Breath of the Wild",
                    Prix = 79.99,
                    IdGenre = 1,
                    Description = "Explorez le vaste monde d'Hyrule en incarnant le héros Link et affrontez de redoutables ennemis.",
                    ImagePath = "/image/LoZeldaBoTW.png"
                },
                new Jeu
                {
                    IdJeu = 3,
                    NomJeu = "Minecraft",
                    Prix = 29.99,
                    IdGenre = 4,
                    Description = "Construisez et explorez un monde infini rempli de blocs, où seules vos limites sont votre créativité et votre imagination.",
                    ImagePath = "/image/Minecraft.png"
                },
                new Jeu
                {
                    IdJeu = 4,
                    NomJeu = "The Witcher 3: Wild Hunt",
                    Prix = 49.99,
                    IdGenre = 3,
                    Description = "Incarnez Geralt de Riv, un puissant chasseur de monstres, et embarquez dans une quête épique à travers un monde fantastique rempli de dangers et de choix moraux.",
                    ImagePath = "/image/TheWitcher3WildHunt.png"
                },
                new Jeu
                {
                    IdJeu = 5,
                    NomJeu = "Rayman Legends",
                    Prix = 39.99,
                    IdGenre = 2,
                    Description = "Rejoignez Rayman and ses amis dans des niveaux colorés et remplis de défis pour sauver le monde des créatures maléfiques.",
                    ImagePath = "/image/RaymanLegends.png"
                },
                new Jeu
                {
                    IdJeu = 6,
                    NomJeu = "Assassin's Creed Origins",
                    Prix = 59.99,
                    IdGenre = 1,
                    Description = "Découvrez l'histoire des origines de la confrérie des Assassins dans l'Égypte antique, et frayez-vous un chemin à travers des batailles épiques et des conspirations.",
                    ImagePath = "/image/ACOrigine.png"
                },
                new Jeu
                {
                    IdJeu = 7,
                    NomJeu = "Terraria",
                    Prix = 19.99,
                    IdGenre = 4,
                    Description = "Explorez, construisez et combattez dans un monde rempli de créatures mystérieuses et de trésors cachés.",
                    ImagePath = "/image/Terraria.png"
                },
                new Jeu
                {
                    IdJeu = 8,
                    NomJeu = "Final Fantasy XIV",
                    Prix = 29.99,
                    IdGenre = 3,
                    Description = "Plongez dans le monde de la saga légendaire Final Fantasy avec des milliers d'autres joueurs dans ce MMORPG riche en histoires et en combats épiques.",
                    ImagePath = "/image/FF14.png"
                },
                new Jeu
                {
                    IdJeu = 9,
                    NomJeu = "Celeste",
                    Prix = 19.99,
                    IdGenre = 2,
                    Description = "Aidez Madeline à surmonter ses peurs intérieures et à escalader la montagne de Celeste dans ce jeu de plateforme acclamé.",
                    ImagePath = "/image/Celeste.png"
                },
                new Jeu
                {
                    IdJeu = 10,
                    NomJeu = "Red Dead Redemption 2",
                    Prix = 59.99,
                    IdGenre = 1,
                    Description = "Explorez le Far West américain à l'époque des hors-la-loi et participez à des braquages, des duels et des aventures épiques.",
                    ImagePath = "/image/RDR2.png"
                },
               
                new Jeu
                {
                    IdJeu = 11,
                    NomJeu = "Stardew Valley",
                    Prix = 14.99,
                    IdGenre = 4,
                    Description = "Quittez la ville pour hériter de la vieille ferme de votre grand-père et transformez-la en un lieu prospère en cultivant des cultures, en élevant du bétail et en tissant des liens avec les habitants de la ville.",
                    ImagePath = "/image/stardewVal.png"
                },
                new Jeu
                {
                    IdJeu = 12,
                    NomJeu = "The Elder Scrolls V: Skyrim",
                    Prix = 39.99,
                    IdGenre = 3,
                    Description = "Un vaste monde ouvert avec des quêtes épiques, des dragons redoutables et des mystères à découvrir.",
                    ImagePath = "/image/skyrim.png"
                },
                new Jeu
                {
                    IdJeu = 13,
                    NomJeu = "Batman: Arkham City",
                    Prix = 39.99,
                    IdGenre = 1,
                    Description = "Incarnez Batman et combattez les super-vilains dans les rues sombres et corrompues d'Arkham City.",
                    ImagePath = "/image/batman.png"
                },
                new Jeu
                {
                    IdJeu = 14,
                    NomJeu = "Minecraft: Dungeons",
                    Prix = 29.99,
                    IdGenre = 1,
                    Description = "Plongez dans des donjons générés de manière procédurale, affrontez des monstres redoutables et obtenez des trésors légendaires dans ce jeu d'action-aventure inspiré de l'univers de Minecraft.",
                    ImagePath = "/image/minecraftDungeon.png"
                },
                new Jeu
                {
                    IdJeu = 15,
                    NomJeu = "RimWorld",
                    Prix = 34.99,
                    IdGenre = 4,
                    Description = "Gérez une colonie de survivants échoués sur une planète extraterrestre dans ce jeu de gestion de colonie complexe et captivant.",
                    ImagePath = "/image/rimworld.png"
                },
                new Jeu
                {
                    IdJeu = 16,
                    NomJeu = "Final Fantasy VII Remake",
                    Prix = 59.99,
                    IdGenre = 3,
                    Description = "Revivez l'histoire épique de Cloud Strife et du groupe de résistants Avalanche dans ce remake du célèbre jeu de rôle japonais.",
                    ImagePath = "/image/ff7remake.png"
                },
                new Jeu
                {
                    IdJeu = 17,
                    NomJeu = "Crash Bandicoot N. Sane Trilogy",
                    Prix = 39.99,
                    IdGenre = 2,
                    Description = "Redécouvrez les aventures classiques de Crash Bandicoot dans une collection remasterisée comprenant les trois premiers jeux de la série.",
                    ImagePath = "/image/trilogy Crash.png"
                },
                new Jeu
                {
                    IdJeu = 18,
                    NomJeu = "The Outer Worlds",
                    Prix = 49.99,
                    IdGenre = 3,
                    Description = "Explorez un univers de science-fiction dystopique, prenez des décisions morales difficiles et façonnez votre propre destinée dans ce RPG captivant.",
                    ImagePath = "/image/TOW.png"
                },
                new Jeu
                {
                    IdJeu = 19,
                    NomJeu = "Super Smash Bros. Ultimate",
                    Prix = 59.99,
                    IdGenre = 1,
                    Description = "Affrontez vos personnages préférés de Nintendo et d'autres franchises dans des combats épiques mettant en scène des crossovers incroyables.",
                    ImagePath = "/image/SSBrosUlti.png"
                },
                new Jeu
                {
                    IdJeu = 20,
                    NomJeu = "Sekiro: Shadows Die Twice",
                    Prix = 59.99,
                    IdGenre = 1,
                    Description = "Affrontez des ennemis redoutables en tant que 'Loup à un bras' dans ce jeu d'action-aventure intense et exigeant développé par FromSoftware.",
                    ImagePath = "/image/seikiro.png"
                },
                new Jeu
                {
                    IdJeu = 21,
                    NomJeu = "Subnautica",
                    Prix = 29.99,
                    IdGenre = 4,
                    Description = "Plongez dans les profondeurs mystérieuses d'une planète océanique extraterrestre et survivez en explorant, en construisant et en découvrant les secrets de ce monde aquatique hostile.",
                    ImagePath = "/image/subnautica.png"
                },
                new Jeu
                {
                    IdJeu = 22,
                    NomJeu = "Divinity: Original Sin 2",
                    Prix = 44.99,
                    IdGenre = 3,
                    Description = "Plongez dans un vaste monde de fantasy et menez une équipe de héros dans une quête pour sauver le monde de la destruction dans ce RPG isométrique riche en choix et en conséquences.",
                    ImagePath = "/image/DOS2.png"
                },
                new Jeu
                {
                    IdJeu = 23,
                    NomJeu = "Doom Eternal",
                    Prix = 39.99,
                    IdGenre = 5,
                    Description = "Affrontez des hordes de démons infernaux dans ce jeu de tir frénétique et sanglant.",
                    ImagePath = "/image/DoomE.png"
                },
                new Jeu
                {
                    IdJeu = 24,
                    NomJeu = "Battlefield V",
                    Prix = 49.99,
                    IdGenre = 5,
                    Description = "Revivez les batailles emblématiques de la Seconde Guerre mondiale dans ce jeu de tir à la première personne.",
                    ImagePath = "/image/BF5.png"
                },
                new Jeu
                {
                    IdJeu = 25,
                    NomJeu = "Madden NFL 23",
                    Prix = 59.99,
                    IdGenre = 7,
                    Description = "Prenez les commandes d'une équipe de football américain et menez-la vers la victoire ultime.",
                    ImagePath = "/image/Madden23.png"
                },
                new Jeu
                {
                    IdJeu = 26,
                    NomJeu = "Amnesia: Rebirth",
                    Prix = 29.99,
                    IdGenre = 10,
                    Description = "Plongez dans une histoire terrifiante et découvrez les sombres secrets qui vous entourent.",
                    ImagePath = "/image/Amnesia.png"
                },
                new Jeu
                {
                    IdJeu = 27,
                    NomJeu = "NBA 2K23",
                    Prix = 59.99,
                    IdGenre = 7,
                    Description = "Dominez le terrain de basket et vivez l'expérience de la NBA avec des joueurs célèbres.",
                    ImagePath = "/image/NBA2K23.png"
                },
                new Jeu
                {
                    IdJeu = 28,
                    NomJeu = "Total War: Warhammer II",
                    Prix = 49.99,
                    IdGenre = 6,
                    Description = "Prenez le contrôle d'une des factions fantastiques de l'univers de Warhammer et dominez le monde.",
                    ImagePath = "/image/TWW2.png"
                },
                new Jeu
                {
                    IdJeu = 29,
                    NomJeu = "Microsoft Flight Simulator",
                    Prix = 59.99,
                    IdGenre = 8,
                    Description = "Envolez-vous dans les cieux et explorez le monde entier avec des détails incroyablement réalistes.",
                    ImagePath = "/image/MFS.png"
                },
                new Jeu
                {
                    IdJeu = 30,
                    NomJeu = "FIFA 23",
                    Prix = 59.99,
                    IdGenre = 7,
                    Description = "Vivez l'excitation du football avec des graphismes réalistes et une jouabilité améliorée.",
                    ImagePath = "/image/fifa23.png"
                },
                 new Jeu
                 {
                     IdJeu = 31,
                     NomJeu = "The Sims 4",
                     Prix = 39.99,
                     IdGenre = 8,
                     Description = "Créez et contrôlez des vies virtuelles dans ce jeu de simulation de vie réaliste.",
                     ImagePath = "/image/sims4.png"
                 },
                new Jeu
                {
                    IdJeu = 32,
                    NomJeu = "Portal 2",
                    Prix = 19.99,
                    IdGenre = 9,
                    Description = "Résolvez des énigmes et manipulez l'espace avec votre pistolet de portail dans ce jeu de puzzle captivant.",
                    ImagePath = "/image/P2.png"
                },
                new Jeu
                {
                    IdJeu = 33,
                    NomJeu = "Call of Duty: Modern Warfare",
                    Prix = 59.99,
                    IdGenre = 5,
                    Description = "Plongez dans une guerre moderne avec des graphismes époustouflants et une expérience multijoueur intense.",
                    ImagePath = "/image/CODMW.png"
                }

            );

            modelBuilder.Entity<GameReview>().HasData(new GameReview
            {
                IdReview = 1,
                User = "admin",
                IdJeu = 1,
                Commentaire = "Ce jeu est incroyable! Les graphismes sont à couper le souffle, et l'histoire est passionnante. J'adore!",
                Note = 4
            },
               new GameReview
               {
                   IdReview = 2,
                   User = "admin",
                   IdJeu = 2,
                   Commentaire = "J'ai passé des heures à jouer à ce jeu. C'est vraiment addictif, et les personnages sont attachants.",
                   Note = 3
               },
               new GameReview
               {
                   IdReview = 3,
                   User = "admin",
                   IdJeu = 3,
                   Commentaire = "Ce jeu mérite 5 étoiles. La jouabilité est fluide, et les niveaux sont bien conçus.",
                   Note = 5
               },
               new GameReview
               {
                   IdReview = 4,
                   User = "admin",
                   IdJeu = 4,
                   Commentaire = "The Witcher 3 est un chef-d'œuvre absolu! L'univers est riche, les quêtes sont captivantes. Ma note : 5/5.",
                   Note = 5
               },
               new GameReview
               {
                   IdReview = 5,
                   User = "admin",
                   IdJeu = 5,
                   Commentaire = "Rayman Legends est un jeu de plateforme incroyablement amusant. Les niveaux musicaux sont géniaux! Note : 4/5.",
                   Note = 4
               },
               new GameReview
               {
                   IdReview = 6,
                   User = "admin",
                   IdJeu = 6,
                   Commentaire = "Assassin's Creed Origins est un voyage passionnant dans l'Égypte antique. Les combats sont géniaux. Note : 4/5.",
                   Note = 4
               },
               new GameReview
               {
                   IdReview = 7,
                   User = "admin",
                   IdJeu = 7,
                   Commentaire = "Terraria est un jeu de construction addictif. L'exploration est infinie! Ma note : 4/5.",
                   Note = 4
               },
               new GameReview
               {
                   IdReview = 8,
                   User = "admin",
                   IdJeu = 8,
                   Commentaire = "Final Fantasy XIV est un MMORPG de qualité avec une histoire épique. Je recommande! Note : 5/5.",
                   Note = 5
               },
               new GameReview
               {
                   IdReview = 9,
                   User = "admin",
                   IdJeu = 9,
                   Commentaire = "Celeste est un jeu de plateforme exigeant mais gratifiant. Les défis sont stimulants. Note : 4/5.",
                   Note = 4
               },
               new GameReview
               {
                   IdReview = 10,
                   User = "admin",
                   IdJeu = 10,
                   Commentaire = "Red Dead Redemption 2 est une expérience immersive dans le Far West. Les détails sont incroyables. Note : 5/5.",
                   Note = 5
               },



               new GameReview
               {
                   IdReview = 11,
                   User = "Grimworld",
                   IdJeu = 1,
                   Commentaire = "Les graphismes de ce jeu sont correct, et l'intrigue est palpitante. Je lui donne 3 étoiles!",
                   Note = 3
               },
               new GameReview
               {
                   IdReview = 12,
                   User = "Grimworld",
                   IdJeu = 2,
                   Commentaire = "J'ai été accro à ce jeu pendant des semaines. Les personnages sont super attachants, et l'aventure est passionnante. Ma note : 4/5.",
                   Note = 4
               },
               new GameReview
               {
                   IdReview = 13,
                   User = "Grimworld",
                   IdJeu = 3,
                   Commentaire = "Ce jeu mérite toutes les éloges. La jouabilité est fluide, et chaque niveau est un plaisir à parcourir. Ma note : 5/5.",
                   Note = 5
               },
               new GameReview
               {
                   IdReview = 14,
                   User = "Tyzral",
                   IdJeu = 1,
                   Commentaire = "Super Mario Odyssey est un jeu incroyable! Les graphismes sont époustouflants, et le gameplay est une pure joie. Ma note : 5/5.",
                   Note = 5
               },
               new GameReview
               {
                   IdReview = 15,
                   User = "Tyzral",
                   IdJeu = 2,
                   Commentaire = "J'ai passé d'innombrables heures à explorer chaque royaume de ce jeu. C'est un chef-d'œuvre du genre. Note : 5/5.",
                   Note = 5
               },
               new GameReview
               {
                   IdReview = 16,
                   User = "Tyzral",
                   IdJeu = 3,
                   Commentaire = "Ce jeu est tellement amusant! Les niveaux sont bien conçus, et les défis sont stimulants. Ma note : 3/5.",
                   Note = 3
               },
               new GameReview
               {
                   IdReview = 17,
                   User = "THEFRIEND",
                   IdJeu = 1,
                   Commentaire = "Ce jeu est décevant. Les graphismes sont médiocres, et l'histoire est ennuyeuse. Ma note : 2/5.",
                   Note = 2
               },
               new GameReview
               {
                   IdReview = 18,
                   User = "THEFRIEND",
                   IdJeu = 2,
                   Commentaire = "The Legend of Zelda: Breath of the Wild est un jeu surévalué. Je ne vois pas ce que les gens lui trouvent. Note : 2/5.",
                   Note = 2
               },
               new GameReview
               {
                   IdReview = 19,
                   User = "THEFRIEND",
                   IdJeu = 3,
                   Commentaire = "Minecraft est un jeu sans intérêt. Construire des choses n'a rien d'amusant. Ma note : 2/5.",
                   Note = 2
               });

            modelBuilder.Entity<Wishlist>().HasData(
                new Wishlist
                {
                    Id = 1,
                    User = "admin"
                  
                },
                 new Wishlist
                 {
                    Id = 2,
                    User = "test1"
                  
                },
                 new Wishlist
                 {
                     Id = 3,
                     User = "test2"

                 }

                );

            
            modelBuilder.Entity<JeuWishlist>().HasData(
                new JeuWishlist
                {
                    WishlistsId = 1,
                    JeuxIdJeu = 1,
                },
                new JeuWishlist
                {
                    WishlistsId = 1,
                    JeuxIdJeu = 2,
                },   
                new JeuWishlist
                {
                    WishlistsId =2,
                    JeuxIdJeu = 1,
                },
                new JeuWishlist
                {
                    WishlistsId = 2,
                    JeuxIdJeu = 2,
                }
                ,
                new JeuWishlist
                {
                    WishlistsId = 3,
                    JeuxIdJeu = 1,
                },
                new JeuWishlist
                {
                    WishlistsId = 3,
                    JeuxIdJeu = 2,
                },
                new JeuWishlist
                {
                    WishlistsId = 3,
                    JeuxIdJeu = 3,
                },
                new JeuWishlist
                {
                    WishlistsId = 3,
                    JeuxIdJeu = 4,
                }


            );

        }

        public DbSet<StoreGame_WebAPI.Entities.Wishlist>? Wishlist { get; set; }
    }


}