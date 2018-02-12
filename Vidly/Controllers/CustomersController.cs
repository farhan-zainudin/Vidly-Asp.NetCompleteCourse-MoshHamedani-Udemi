using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _DbContext;

        public CustomersController()
        {
            _DbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _DbContext.Dispose();
        }

        public ActionResult New()
        {
            return View();
        }

        // GET: Customers
        [Route("Customers")]
        public ActionResult Customers()
        {
            var customers = _DbContext.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        
        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _DbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound("The Customers is not Found or doesn't exist.");

            return View(customer);
        }
    }
}