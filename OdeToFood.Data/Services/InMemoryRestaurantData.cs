using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Taste of Italy", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 3, Name = "Spice Delight", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 4, Name = "Le Croissant", Cuisine = CuisineType.French },
                new Restaurant { Id = 5, Name = "Mamma Mia", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 6, Name = "Curry Palace", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 7, Name = "Bistro Bon Appétit", Cuisine = CuisineType.French },
                new Restaurant { Id = 8, Name = "Pasta Paradiso", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 9, Name = "Tandoori Nights", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 10, Name = "La Belle Cuisine", Cuisine = CuisineType.French }
            };
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
