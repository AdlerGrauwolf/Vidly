using System.Collections.Generic;

using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<MovieGenre> Genres { get; set; }

        public bool UserIsInRole { get; set; }
    }
}