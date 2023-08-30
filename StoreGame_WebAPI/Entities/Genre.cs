using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StoreGame_WebAPI.entities
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        [Column("idGenre")]
        public int IdGenre { get; set; }

        public string Name { get; set; }

        public Genre()
        {
        }

        public Genre(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
