using StoreGame_WebAPI.entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreGame_WebAPI.Entities
{
    public class JeuWishlist
    {
        [ForeignKey("Jeu")]
        public int JeuxIdJeu { get; set; }

        [ForeignKey("Wishlist")]
        public int WishlistsId { get; set; }

        public Jeu Jeu { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
