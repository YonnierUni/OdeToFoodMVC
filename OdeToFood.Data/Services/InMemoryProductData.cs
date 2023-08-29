using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryProductData : IProductData
    {
        List<Product> products;

        public InMemoryProductData()
        {
            products = new List<Product>()
            {
                new Product { Id = 1, Name = "Scott's Pizza", Property = ProductType.Apartamentos, Status = ProductStatus.Inactive },
                new Product { Id = 2, Name = "Taste of Italy", Property = ProductType.Bienes, Status = ProductStatus.Inactive  },
                new Product { Id = 3, Name = "Spice Delight", Property = ProductType.Bienes, Status = ProductStatus.Active  },
                new Product { Id = 4, Name = "Le Croissant", Property = ProductType.Terrenos, Status = ProductStatus.Inactive  },
                new Product { Id = 5, Name = "Mamma Mia", Property = ProductType.Bienes, Status = ProductStatus.Inactive  },
                new Product { Id = 6, Name = "Curry Palace", Property = ProductType.Apartamentos, Status = ProductStatus.Active  },
                new Product { Id = 7, Name = "Bistro Bon Appétit", Property = ProductType.Vehiculos, Status = ProductStatus.Inactive  },
                new Product { Id = 8, Name = "Pasta Paradiso", Property = ProductType.Apartamentos, Status = ProductStatus.Active  },
                new Product { Id = 9, Name = "Tandoori Nights", Property = ProductType.Terrenos, Status = ProductStatus.Inactive  },
                new Product { Id = 10, Name = "La Belle Property", Property = ProductType.Bienes, Status = ProductStatus.Inactive  }
            };
        }

        public void Add(Product product)
        {
            products.Add(product);
            product.Id = products.Max(x => x.Id) + 1;
        }

        public void Delete(int id)
        {
            var product = Get(id);
            if (product != null)
            {
                products.Remove(product);
            }
        }

        public Product Get(int id)
        {
            return products.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products.OrderBy(r => r.Name);
        }

        public void Update(Product product)
        {
            var existing = Get(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Property = product.Property;
            }
        }
    }
}
