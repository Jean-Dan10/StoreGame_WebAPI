using StoreGame_WebAPI.entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreGame_WebAPI.DTO
{
    public class GameReviewsWithGameNameDTO
    {
       
        public string User { get; set; }
        public int IdJeu { get; set; }
        public string NomJeu { get; set; }
        public string Commentaire { get; set; }
        public int Note { get; set; }


    }
}
