using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Index()
        {
            var movies = GetAllMovies();
            return View(movies);
        }
        public ActionResult Details(int? id)
        {
            var movies = GetAllMovies();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = (Movie)movies.Find(x => x.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
        public ActionResult Random()
        {
            var movie = new Movie(){ Name = "Shreik!" };
            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel();
            viewModel.Movie = movie;
            viewModel.Customers = customers;

            return View(viewModel);
        }

        private List<Movie> GetAllMovies()
        {
            var movies = new List<Movie>
            {
                new Movie(){Id = 1, Name = "Avengers-Infinity War"},
                new Movie(){Id = 2, Name = "Superman-Man of steel"}
            };

            return movies;
        }

        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
        //public ActionResult Edit(int id)
        //{
        //    return Content("id = " + id);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        //}
    }
}