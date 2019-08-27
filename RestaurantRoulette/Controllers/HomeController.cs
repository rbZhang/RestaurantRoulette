using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantRoulette.Models;
using System.Net;
using Newtonsoft.Json;

namespace RestaurantRoulette.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(SearchModel model)
        {
            var zomatoApiKey = "022edde1bef9a9421e14b38e6befd929";
            var mealType = model.mealType;
            var latitude = model.latitude;
            var longitude = model.longitutde;
            var client = new WebClient();
            var json = client.DownloadString("https://developers.zomato.com/api/v2.1/search?q=" + mealType + "&lat=" + latitude + "&lon=" + longitude + "&apikey=" + zomatoApiKey + "&sort=real_distance");
            var results = JsonConvert.DeserializeObject<RestaurantWrapper>(json);

            if (results.NumberResults < 100000)
            {
                var lastProperty = results.Restaurants.Count;
                var randomNumber = new Random().Next(0, lastProperty);

                return View("Result", results.Restaurants[randomNumber]);              
            }
            else
            {
                TempData["notice"] = "No results found";
                return View("Index");
            }
        }
    }
}
