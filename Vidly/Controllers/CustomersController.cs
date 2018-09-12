using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly List<Customer> _customers = default(List<Customer>);

        public CustomersController()
        {
            _customers = new List<Customer>() {
                new Customer(){Id = 1, Name = "John Smith"},
                new Customer(){Id = 2, Name = "Mary Williams"}
            };
        }

        // GET: Costumers
        public ActionResult Index()
        {
            return View(_customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}