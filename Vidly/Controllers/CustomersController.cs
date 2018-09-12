using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context = default(ApplicationDbContext);

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Costumers test
        public ActionResult Index()
        {
            // Eager loading    
            var customer = _context.Customers
                                   .Include(c => c.MembershipType)
                                   .ToList();

            return View(customer);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}