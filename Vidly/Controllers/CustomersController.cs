using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        [Route("Customers")]
        public ActionResult Customers()
        {
            var list = GetCustomers();
            return View(list);
        }
        
        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().Single(x => x.Id == id);
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> customer = new List<Customer>()
            {
                new Customer{ Id = 1, Name = "Pedro Martinez" },
                new Customer{ Id = 2, Name = "Janna Aquino" },
                new Customer{ Id = 3, Name = "Lisbeth Naomi" }
            };

            return customer;
        }
    }
}