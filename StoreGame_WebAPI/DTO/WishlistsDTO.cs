namespace StoreGame_WebAPI.DTO
{
    public class WishlistsDTO
    {
        public int IdWishlist { get; set; }
        public string User { get; set; }
        public List<string> NomsJeux { get; set; }

    }
}
