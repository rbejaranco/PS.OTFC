using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFoodCore.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IConfiguration Config { get; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
            IRestaurantData restaurantData)
        {
            Config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = Config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}