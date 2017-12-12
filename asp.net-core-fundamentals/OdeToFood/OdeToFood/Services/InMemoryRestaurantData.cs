using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        // CAUTION - NOT THREAD SAFE!!
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Restuarant A" },
                new Restaurant { Id = 2, Name = "Restaurant B" },
                new Restaurant { Id = 3, Name = "Restaurant C" },
                new Restaurant { Id = 4, Name = "Restaurant D" },
                new Restaurant { Id = 5, Name = "Restaurant E" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            // CAUTION - NOT THREAD SAFE!!
            return _restaurants.OrderBy(r => r.Name);
        }
    }
}
