using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFoodMVC.Web.Api
{
    public class ProductsController : ApiController
    {
        private readonly IProductData db;

        public ProductsController(IProductData db)
        {
            this.db = db;
        }

        public IEnumerable<Product> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
