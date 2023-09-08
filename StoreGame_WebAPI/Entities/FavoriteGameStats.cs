using Microsoft.EntityFrameworkCore;

namespace StoreGame_WebAPI.Entities
{
    [Keyless]
    public class FavoriteGameStats
    {
        public int IdJeu { get; set; }
        public string GameName { get; set; }
        public int TotalWishlists { get; set; }
        public double PercentInWishlists { get; set; }
    }
}
