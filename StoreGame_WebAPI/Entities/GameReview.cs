using StoreGame_WebAPI.entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreGame_WebAPI.Entities
{
    [Table("GameReview")]
    public class GameReview
    {
        
        [Key]
        public int IdReview  {set;get;}

        [ForeignKey("Compte")]
        public string User { get; set; }
        public Compte Compte { get; set; }

        [ForeignKey("Jeu")]
        public int IdJeu { get; set; }
        public Jeu Jeu { get; set; } 
        public string Commentaire { get; set; }
        public int Note {get; set; }




    }
}
