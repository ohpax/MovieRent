using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> movies = new List<Movie>()
        {
            new Movie() {Id = 1, Name = "Runner"},
            new Movie() {Id = 2, Name = "Breave Harth"},
            new Movie() {Id = 3, Name = "Fast and furiest"},
            new Movie() {Id = 4, Name = "Kickboxer"}
        };

        // GET: Movies/Random
        public ActionResult Random()
        {
            Movie movie = new Movie() {Name = "Shrek!"};
            
            List<Customer> customers = new List<Customer>()
            {
                new Customer() {Name = "Customer 1"},
                new Customer() {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            //return Content($"pageIndex={pageIndex}&sotBy={sortBy}");
            return View(movies);
        }

        [Route("Movies/Released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content($"{year} / {month}");
        }

        public ActionResult Details(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);

            return View(movie);
        }
    }
}