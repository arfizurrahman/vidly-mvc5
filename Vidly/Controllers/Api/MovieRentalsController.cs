using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
    public class MovieRentalsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateNewRentals(MovieRentalDto movieRentalDto)
        {
            return Ok();
        }
    }
}
