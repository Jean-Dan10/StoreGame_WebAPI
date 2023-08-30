using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StoreGame_WebAPI.entities
{
    
    [Table("Commande")]
    public class Commande
    {
        [Key]
        [Column("idCommande")]
        public int IdCommande { get; set; }

        [ForeignKey("Compte")]
        public int IdCompte { get; set; }
        public Compte Compte { get; set; }

        public List<Jeu> Jeux { get; set; } = new List<Jeu>();

        public bool Panier { get; set; }

        public Commande()
        {
        }

        public Commande(Compte compte, bool panier)
        {
            Compte = compte;
            Panier = panier;
        }

        public void RemoveJeu(int idJeu)
        {
            Jeux.RemoveAll(jeu => jeu.IdJeu == idJeu);
            // Update logic as needed
        }

        public void AddJeu(Jeu jeu)
        {
            Jeux.Add(jeu);
            // Update logic as needed
        }

        public override string ToString()
        {
            return $"Commande{{ IdCommande={IdCommande}, Jeux={Jeux}, Panier={Panier} }}";
        }
    
}
}
