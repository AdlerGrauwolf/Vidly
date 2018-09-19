using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        #region Notes
        // Property attribute routing example: [Route("movies/released/{year:regex(\\d{4}):range(1900, 2100)}/{month:regex(\\d{2}):range(1,2)}")]
        #endregion

        private readonly ApplicationDbContext _context = default(ApplicationDbContext);

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies
                                 .Include(m => m.MovieGenre)
                                 .ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies
                                  .Include(m => m.MovieGenre)
                                  .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.MovieGenre.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.MovieGenre.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == default(int))
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.MovieGenreId = movie.MovieGenreId;
                movieInDb.InStock = movie.InStock;
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index", "Movie");
        }
    }
}