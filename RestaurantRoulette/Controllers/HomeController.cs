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
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                var client = new WebClient();

                var googleApiKey = "GoogleApiKey";
                var address = model.Address;
                var addressJson = client.DownloadString("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + googleApiKey);
                var addressResult = JsonConvert.DeserializeObject<LocationModel>(addressJson);

                var zomatoApiKey = "ZomatoApiKey";
                var mealType = model.MealType;
                var latitude = addressResult.Results[0].Geometry.Location.Lat;
                var longitude = addressResult.Results[0].Geometry.Location.Lng;

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
                    return View("Index");
                }
            }
        }
    }
}
