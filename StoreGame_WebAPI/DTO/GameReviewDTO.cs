namespace StoreGame_WebAPI.DTO
{
    public class GameReviewDTO
    {
        public int IdReview { get; set; }
        public string User { get; set; }
        public string NomJeu { get; set; }
        public string Commentaire { get; set; }
        public int Note { get; set; }
    }
}
