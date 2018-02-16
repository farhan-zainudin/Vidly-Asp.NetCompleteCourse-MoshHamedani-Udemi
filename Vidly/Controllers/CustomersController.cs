using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _dbContext.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
                _dbContext.Customers.Add(customer);
            else
            {
                UpdateModel(customer);
            }

            _dbContext.SaveChanges();
            return RedirectToAction("Customers", "Customers");
        }

        private void UpdateModel(Customer customer)
        {
            var customerInDb = _dbContext.Customers
                                .Single(x => x.Id == customer.Id);

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSuscribedToNewsLetter = customer.IsSuscribedToNewsLetter;
        }

        // GET: Customers
        [Route("Customers")]
        public ActionResult Customers()
        {
            //if (MemoryCache.Default["Genres"] == null)
            //{
            //    MemoryCache.Default["Genres"] = _dbContext.Genres.ToList();
            //}

            //var genre = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            return View();
        }
        
        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound("The Customers is not Found or doesn't exist.");

            return View(customer);
        }

        [Route("Customers/New")]
        public ActionResult New()
        {
            var membership = _dbContext.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membership
            };
            return View("CustomerForm", viewModel);
        }

        [Route("Customers/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers
                .SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound("The customer its not found");

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes =  _dbContext.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}