using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

using AutoMapper;

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
            var viewModel = new CustomerFormViewModel();
            viewModel.Customer = new Customer();
            viewModel.MembershipTypes = _context.MembershipTypes.ToList();

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            // Access to validation data
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            // The view contains all the properties of the Customer model
            // so it can mapp the values correctly regarding its model its of type NewCustomerViewModel
            // (NewCustomerViewModel contains a property of type Customer) 
            if (customer.Id == default(int))
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // You can use automaper like this:
                Mapper.Map(customer, customerInDb);

                // Or you can also map the fields manually like this: 
                //customerInDb.Name = customer.Name;
                //customerInDb.Birthday = customer.Birthday;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId;
                //customerInDb.IsSubscribedToNewsLatter = customer.IsSubscribedToNewsLatter;            
            }

            _context.SaveChanges();
                            

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}