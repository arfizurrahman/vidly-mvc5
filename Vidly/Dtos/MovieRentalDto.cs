﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieRentalDto
    {
       
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}