using System;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            var model = new Restaurant
            { 
                Id = 1, 
                Name = "Linda's Vegan Kitchen"
            };
            return new ObjectResult(model);

            //return Content("Hello from HomeController.Index(), returning IActionResult and extending base Controller");
        }
    }
}