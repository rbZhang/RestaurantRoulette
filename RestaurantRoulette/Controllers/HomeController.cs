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
        [HttpGet]
        public IActionResult Index()
        {
            var client = new WebClient();
            var json = client.DownloadString("https://developers.zomato.com/api/v2.1/search?entity_id=59&entity_type=city&apikey=022edde1bef9a9421e14b38e6befd929");
            var results = JsonConvert.DeserializeObject<RestaurantWrapper>(json);
            var lastProperty = results.Restaurants.Count;
            var randomNumber = new Random().Next(0, lastProperty);
            return View(results.Restaurants[randomNumber]);
        }

        [HttpGet]
        public ActionResult Search(SearchModel model)
        {
            var radius = model.Radius;
            var client = new WebClient();
            var json = client.DownloadString("https://developers.zomato.com/api/v2.1/search?entity_id=59&entity_type=city&&apikey=022edde1bef9a9421e14b38e6befd929");
            var results = JsonConvert.DeserializeObject<RestaurantWrapper>(json);
            var lastProperty = results.Restaurants.Count;
            var randomNumber = new Random().Next(0, lastProperty);

            return View();
        }
    }
}
