using StoreGame_WebAPI.entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreGame_WebAPI.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }
        [ForeignKey("Compte")]
        public string User { get; set; }
        public Compte? Compte { get; set; }
        public List<Jeu> Jeux { get; set; } = new List<Jeu>();

    }
}
