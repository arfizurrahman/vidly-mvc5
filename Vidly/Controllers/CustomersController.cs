using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetAllCustomers();
            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            var customers = GetAllCustomers();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = (Customer) customers.Find(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
             
            return View(customer);
        }
        private List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Mary Williams"}
            };
            return customers;
        }
    }
}