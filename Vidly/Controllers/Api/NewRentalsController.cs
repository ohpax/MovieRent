using System;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Customer is not valid.");


            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");

            foreach (var m in movies)
            {
                if (m.NumberAvailable == 0)
                    return BadRequest("Movie is not Available.");

                m.NumberAvailable = m.NumberAvailable - 1;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = m,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);



            }
        
                _context.SaveChanges();
  

            return Ok();
        }
    }
}
