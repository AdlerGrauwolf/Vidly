using System.Collections.Generic;
using System.Web.Mvc;

using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly List<Movie> _movies = default(List<Movie>);

        public MoviesController()
        {
            _movies = new List<Movie>()
            {
                new Movie() { Id = 1, Name = "Shrek" },
                new Movie() { Id = 2, Name = "Wall-e" }
            };
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View(_movies);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>()
            {
                new Customer(){ Name = "Customer 1" },
                new Customer(){ Name = "Customer 2" }
            };

            var randomViewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomViewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content($"Id = {id}");
        }

        [Route("movies/released/{year:regex(\\d{4}):range(1900, 2100)}/{month:regex(\\d{2}):range(1,2)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }
    }
}