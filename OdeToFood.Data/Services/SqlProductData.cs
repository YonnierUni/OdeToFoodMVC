﻿using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlProductData : IProductData
    {
        private readonly ProductsDbContext db;
        public SqlProductData(ProductsDbContext db)
        {
            this.db = db;
        }
        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product Get(int id)
        {
            return db.Products.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return from r in db.Products
                   orderby r.Name
                   select r;
        }

        public void Update(Product product)
        {
            var entry = db.Entry(product);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
