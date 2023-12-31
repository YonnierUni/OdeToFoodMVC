﻿using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFoodMVC.Web.Models
{
    public class GreetingViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
    }
}