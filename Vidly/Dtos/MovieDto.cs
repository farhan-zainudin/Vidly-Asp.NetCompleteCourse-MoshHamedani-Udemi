using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1,40)]
        public int? Stock { get; set; }

        [Required]
        public int? GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}