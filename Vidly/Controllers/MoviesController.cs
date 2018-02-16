using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private ApplicationDbContext _dbContext;
        
        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _dbContext.Genres.ToList()
                };

                return View("MoviesForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _dbContext.Movies.Add(movie);
            }
            else
            {
                UpdateModel(movie);
            }


            try
            {
                _dbContext.SaveChanges();
                
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("Movies", "Movies");
        }

        [Route("Movies")]
        public ActionResult Movies()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Movies");

            return View("ReadOnlyMovies");
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies
                .Include(x => x.Genre)
                .Single(x => x.Id == id);

            return View(movie);
        }

        [Route("Movies/New")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View("MoviesForm", viewModel);
        }

        [Route("Movies/Edit/{id}")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _dbContext.Movies.Single(x => x.Id == id);

            if (movie == null)
                return HttpNotFound("The movie its not found");

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View("MoviesForm", viewModel);
        }


        private void UpdateModel(Movie movie)
        {
            var movieInDb = _dbContext.Movies
                .Single(x => x.Id == movie.Id);

            movieInDb.DateAdded = movie.DateAdded;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.Stock = movie.Stock;
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



    }
}