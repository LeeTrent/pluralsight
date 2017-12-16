using System;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            //var model = new Restaurant
            //{ 
            //    Id = 1, 
            //    Name = "Linda's Vegan Kitchen"
            //};

            //var model = _restaurantData.GetAll();

            var viewModel = new HomeIndexViewModel();
            viewModel.Restaurants = _restaurantData.GetAll();
            viewModel.CurrentMessage = _greeter.getMessageOfTheDay();

            return View(viewModel);

            //return new ObjectResult(model);
            //return Content("Hello from HomeController.Index(), returning IActionResult and extending base Controller");
        }

        public IActionResult Details(int id) 
        {
            var model = _restaurantData.Get(id);
            if (model == null) 
            {
                //return NotFound();
                return RedirectToAction(nameof(Index));
            }
            return View(model);

            //return Content(id.ToString());
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditModel viewModel)
        {
            var model = new Restaurant();
            model.Name = viewModel.Name;
            model.Cuisine = viewModel.Cuisine;

            model = _restaurantData.Add(model);

            //return Content("POST");
            //return View("Details", model);
            return RedirectToAction ( nameof(Details), new { id = model.Id } );
        }
    }
}