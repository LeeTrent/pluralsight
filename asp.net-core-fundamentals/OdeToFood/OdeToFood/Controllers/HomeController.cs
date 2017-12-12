using System;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            //var model = new Restaurant
            //{ 
            //    Id = 1, 
            //    Name = "Linda's Vegan Kitchen"
            //};

            var model = _restaurantData.GetAll();
            return View(model);

            //return new ObjectResult(model);
            //return Content("Hello from HomeController.Index(), returning IActionResult and extending base Controller");
        }
    }
}