using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        #region Notes
        // Property attribute routing example: [Route("movies/released/{year:regex(\\d{4}):range(1900, 2100)}/{month:regex(\\d{2}):range(1,2)}")]
        #endregion

        private readonly ApplicationDbContext _context = default(ApplicationDbContext);

        public MoviesController()
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
    }
}