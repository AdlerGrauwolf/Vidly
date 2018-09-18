using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context = default(ApplicationDbContext);

        public CustomerController()
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
            Customer customer = _context.Customers
                                        .Include(c => c.MembershipType)
                                        .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var viewModel = new NewCustomerViewModel();
            viewModel.MembershipTypes = _context.MembershipTypes.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            // The view contains all the properties of the Customer model
            // so it can mapp the values correctly regarding its model its of type NewCustomerViewModel
            // (NewCustomerViewModel contains a property of type Customer) 
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
    }
}