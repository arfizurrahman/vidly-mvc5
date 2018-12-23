using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieRentalsController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult CreateNewRentals(MovieRentalDto movieRentalDto)
        {
            var customer = _context.Customers.Single(
                c => c.Id == movieRentalDto.CustomerId);

            var movies = _context.Movies.Where(
                m => movieRentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movieRentalDto.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }

        //Defensive approach to validate edge cases
        //public IHttpActionResult CreateNewRentals(MovieRentalDto movieRentalDto)
        //{
        //    if (movieRentalDto.MovieIds.Count == 0)
        //        return BadRequest("No Movie Ids have been given.");

        //    var customer = _context.Customers.Single(
        //        c => c.Id == movieRentalDto.CustomerId);
        //    if (customer == null)
        //        return BadRequest("Customer Id is not valid");

        //    var movies = _context.Movies.Where(
        //        m => movieRentalDto.MovieIds.Contains(m.Id)).ToList();

        //    if (movies.Count != movieRentalDto.MovieIds.Count)
        //        return BadRequest("One or more movie ids are invalid");

        //    foreach (var movie in movies)
        //    {

        //        movie.NumberAvailable--;
        //        var rental = new Rental
        //        {
        //            Customer = customer,
        //            Movie = movie,
        //            DateRented = DateTime.Now
        //        };

        //        _context.Rentals.Add(rental);
        //    }

        //    _context.SaveChanges();
        //    return Ok();
        //}
    }

}
