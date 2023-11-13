using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // 255
        [MaxLength(100)]
        public required string Name { get; set; }

        public ICollection<Movie>Movies { get; set; } = new List<Movie>();
    }
}
