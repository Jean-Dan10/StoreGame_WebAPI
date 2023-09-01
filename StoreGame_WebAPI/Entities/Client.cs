using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StoreGame_WebAPI.entities
{


    [Table("Client")]
    public class Client
    {
        [Key]
        [Column("idClient")]
        public int IdClient { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AdressePhysique { get; set; }
        public string AdresseCourriel { get; set; }

        [ForeignKey("Compte")]
        public string User { get; set; }
        public Compte? Compte { get; set; }

    }
}
