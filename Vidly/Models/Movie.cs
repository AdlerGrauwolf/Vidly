using System;
using System.ComponentModel;
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
        [DisplayName("Genre")]
        public byte MovieGenreId { get; set; }

        [DisplayName("Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [DisplayName("Number in Stock")]
        public int InStock { get; set; }
    }
}