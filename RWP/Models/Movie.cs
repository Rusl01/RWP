using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RWP.Models
{
    public class Movie
    {
        public int Id { get; set; }
         public string? Title { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string? Genre { get; set; } = null;
        public decimal Price { get; set; } = decimal.Zero;
        public string Rating { get; set; } = string.Empty;
    }
}
