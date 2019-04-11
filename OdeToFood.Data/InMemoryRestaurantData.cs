using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant(){ Id=1, Name="Harry's Sasson", Cuisine= Restaurant.CuisineType.Indian, Location="Bogota"  },
                new Restaurant(){ Id=2, Name="Andres Carne de Res", Cuisine= Restaurant.CuisineType.Italian, Location="Cajica"  },
                new Restaurant(){ Id=3, Name="Raton Rouge", Cuisine= Restaurant.CuisineType.Mexican, Location="Montreal"  },
                new Restaurant(){ Id=4, Name="Tassot", Cuisine= Restaurant.CuisineType.Non, Location="Brossard"  }
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault( r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
