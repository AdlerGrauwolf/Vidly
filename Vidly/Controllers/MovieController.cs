using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

using AutoMapper;

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
            var viewModel = new MovieViewModel()
            {
                UserIsInRole = User.IsInRole(RoleName.CanManageMovies)
            };
            
            return View(viewModel);
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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieViewModel()
            {
                Genres = _context.MovieGenre.ToList(),
                Movie = new Movie()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieViewModel()
            {
                Movie = movie,
                Genres = _context.MovieGenre.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel()
                {
                    Movie = movie,
                    Genres = _context.MovieGenre.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == default(int))
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
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