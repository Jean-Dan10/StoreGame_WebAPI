﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreGame_WebAPI.Data;

#nullable disable

namespace StoreGame_WebAPI.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20230831011630_AddingGameReviewAndWishList")]
    partial class AddingGameReviewAndWishList
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommandeJeu", b =>
                {
                    b.Property<int>("CommandesIdCommande")
                        .HasColumnType("int");

                    b.Property<int>("JeuxIdJeu")
                        .HasColumnType("int");

                    b.HasKey("CommandesIdCommande", "JeuxIdJeu");

                    b.HasIndex("JeuxIdJeu");

                    b.ToTable("CommandeJeu");
                });

            modelBuilder.Entity("StoreGame_WebAPI.Entities.GameReview", b =>
                {
                    b.Property<int>("IdReview")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReview"));

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdJeu")
                        .HasColumnType("int");

                    b.Property<int>("Note")
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdReview");

                    b.HasIndex("IdJeu");

                    b.HasIndex("User", "IdJeu")
                        .IsUnique();

                    b.ToTable("GameReview");
                });

            modelBuilder.Entity("StoreGame_WebAPI.Entities.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("User")
                        .IsUnique();

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("StoreGame_WebAPI.entities.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idClient");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("AdresseCourriel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdressePhysique")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompteUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.HasIndex("CompteUser");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("StoreGame_WebAPI.entities.Commande", b =>
                {
                    b.Property<int>("IdCommande")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCommande");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCommande"));

                    b.Property<bool>("Panier")
                        .HasColumnType("bit");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdCommande");

                    b.HasIndex("User");

                    b.ToTable("Commande");
                });

            modelBuilder.Entity("StoreGame_WebAPI.entities.Compte", b =>
                {
                    b.Property<string>("User")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User");

                    b.ToTable("Compte");
                });

            modelBuilder.Entity("StoreGame_WebAPI.entities.Genre", b =>
                {
                    b.Property<int>("IdGenre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idGenre");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGenre"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGenre");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("StoreGame_WebAPI.entities.Jeu", b =>
                {
                    b.Property<int>("IdJeu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idJeu");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJeu"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdGenre")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomJeu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<int?>("WishlistId")
                        .HasColumnType("int");

                    b.HasKey("IdJeu");

                    b.HasIndex("IdGenre");

                    b.HasIndex("WishlistId");

                    b.ToTable("Jeu");
                });

            modelBuilder.Entity("CommandeJeu", b =>
                {
                    b.HasOne("StoreGame_WebAPI.entities.Commande", null)
                        .WithMany()
                        .HasForeignKey("CommandesIdCommande")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreGame_WebAPI.entities.Jeu", null)
                        .WithMany()
                        .HasForeignKey("JeuxIdJeu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreGame_WebAPI.Entities.GameReview", b =>
                {
                    b.HasOne("StoreGame_WebAPI.entities.Jeu", "Jeu")
                        .WithMany()
                        .HasForeignKey("IdJeu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreGame_WebAPI.entities.Compte", "Compte")
                        .WithMany()
                        .HasForeignKey("User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");

                    b.Navigation("Jeu");
                });

            modelBuilder.Entity("StoreGame_WebAPI.Entities.Wishlist", b =>
                {
                    b.HasOne("StoreGame_WebAPI.entities.Compte", "Compte")
                        .WithOne("Wishlist")
                        .HasForeignKey("StoreGame_WebAPI.Entities.Wishlist", "User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");
                });

            modelBuilder.Entity("StoreGame_WebAPI.entities.Client", b =>
                {
                    b.HasOne("StoreGame_WebAPI.entities.Compte", "Compte")
                        .WithMany()
                        .HasForeignKey("CompteUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");
                });

            modelBuilder.Entity("StoreGame_WebAPI.entities.Commande", b =>
                {
                    b.HasOne("StoreGame_WebAPI.entities.Compte", "Compte")
                        .WithMany("Commandes")
                        .HasForeignKey("User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");
                });

            modelBuilder.Entity("StoreGame_WebAPI.entities.Jeu", b =>
                {
                    b.HasOne("StoreGame_WebAPI.entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("IdGenre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreGame_WebAPI.Entities.Wishlist", null)
                        .WithMany("Jeux")
                        .HasForeignKey("WishlistId");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("StoreGame_WebAPI.Entities.Wishlist", b =>
                {
                    b.Navigation("Jeux");
                });

            modelBuilder.Entity("StoreGame_WebAPI.entities.Compte", b =>
                {
                    b.Navigation("Commandes");

                    b.Navigation("Wishlist")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
