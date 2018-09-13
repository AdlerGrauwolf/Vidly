using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public MovieGenre MovieGenre { get; set; }

        [Required]
        public byte MovieGenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int InStock { get; set; }
    }
}