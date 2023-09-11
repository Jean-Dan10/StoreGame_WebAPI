using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StoreGame_WebAPI.Entities;

namespace StoreGame_WebAPI.entities
{
    [Table("Compte")]
    public class Compte
    {
        [Key]     
        public string User { get; set; }

       
        public string Password { get; set; }

       
        public string ProfileName { get; set; }

        public List<Commande> Commandes { get; set; } = new List<Commande>();

        public Wishlist Wishlist { get; set; }

        public Compte()
        {
        }

        public Compte(string user, string password, string profileName)
        {
            User = user;
            Password = password;
            ProfileName = profileName;
        }

        //mise en commentaire du code car n'est pas utiliser

        //public Commande TrouvePanier()
        //{
        //    foreach (Commande commande1 in Commandes)
        //    {
        //        if (commande1.IsPanier())
        //        {
        //            return commande1;
        //        }
        //    }
        //    return null;
        //}

        //public void UpdateCommande(Commande commande)
        //{
        //    for (int i = 0; i < Commandes.Count; i++)
        //    {
        //        if (Commandes[i].IdCommande == commande.IdCommande)
        //        {
        //            Commandes[i] = commande;
        //        }
        //    }
        //}

        //public void RemoveCommande(Commande commande)
        //{
        //    Commandes.RemoveAll(c => c.IdCommande == commande.IdCommande);
        //}

        //public void CreatePanier(Commande panier)
        //{
        //    Commandes.Add(panier);
        //}

        public override string ToString()
        {
            return $"Compte{{  User='{User}', Password='{Password}', ProfileName='{ProfileName}', Commandes={Commandes} }}";
        }
    }

}
