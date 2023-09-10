using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StoreGame_WebAPI.Entities;

namespace StoreGame_WebAPI.entities
{
    [Table("Jeu")]
    public class Jeu
    {
        [Key]
        [Column("idJeu")]
        public int IdJeu { get; set; }

        public string NomJeu { get; set; }
        public double Prix { get; set; }

        [ForeignKey("Genre")]
        public int IdGenre { get; set; }
        public Genre? Genre { get; set; }

        public string? Description { get; set; }
        public string? ImagePath { get; set; }

        public List<Commande> Commandes { get; set; } = new List<Commande>();

        public List<Wishlist> Whislists { get; set; } = new List<Wishlist>();
        public List<JeuWishlist> JeuWishlists { get; set; } = new List<JeuWishlist>();

        public Jeu()
        {
        }

        public Jeu(string nomJeu, double prix, Genre genre, string description)
        {
            NomJeu = nomJeu;
            Prix = prix;
            Genre = genre;
            Description = description;
        }

        public Jeu(string nomJeu, double prix, Genre genre, string description, string imagePath)
        {
            NomJeu = nomJeu;
            Prix = prix;
            Genre = genre;
            Description = description;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"Jeu{{ IdJeu={IdJeu}, NomJeu='{NomJeu}', Prix={Prix}, Genre='{Genre}', Description='{Description}' }}";
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            Jeu jeu = (Jeu)obj;
            return IdJeu == jeu.IdJeu;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdJeu);
        }
    }
}
