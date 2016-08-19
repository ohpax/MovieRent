using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>()
            {
                new Customer() {Id=1, Name = "John Smith"},
                new Customer() {Id = 2, Name = "Askhare Farhadi"},
                new Customer() {Id = 3, Name = "Mary Williams"},
                new Customer() {Id = 4, Name = "Amir Galenoyi"}
            };
        // GET: Customer
        public ActionResult Index()
        {
            ViewBag.Title = "Customer Page";

            customers = null;
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}