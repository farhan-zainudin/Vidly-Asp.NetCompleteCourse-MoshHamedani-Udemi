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
        [Route("Movies")]
        public ActionResult Movies()
        {
            var list = GetMovies();

            return View(list);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = GetMovies().Single(x=> x.Id == id);

            return View(movie);
        }


        // GET: Movies/Random
        [Route("Movies/Random")]
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek"
            };

            var costumers = new List<Customer>()
            {
                new Customer {Name = "Pedro"},
                new Customer {Name = "Juan"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Costumers = costumers
            };

            return View(viewModel);
        }

        [Route("Movies/Release/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            IEnumerable<Movie> movies = new List<Movie>()
            {
                new Movie{ Id = 1, Name= "Black Panther"},
                new Movie{ Id = 2, Name= "Avengers Infinity War Part I"}
            };

            return movies;
        }
    }
}