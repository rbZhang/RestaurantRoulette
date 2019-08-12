using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRoulette.Models
{

    public class RestaurantWrapper
    {
        public List<Restaurants> Restaurants { get; set; }
    }

    public class Restaurants
    {
        public Restaurant Restaurant { get; set; }
    }

    public class Restaurant
    {
        public string Name { get; set; }

        [JsonProperty("location")]
        public Location Locations { get; set; }

        [JsonProperty("user_rating")]
        public Rating Ratings { get; set; }

        [JsonProperty("thumb")]
        public string Thumbnail { get; set; }

        public class Location
        {
            public string Address { get; set; }
        }
        public class Rating
        {
            [JsonProperty("aggregate_rating")]
            public string AverageRating { get; set; }

            [JsonProperty("votes")]
            public int NumberReview { get; set; }
        }
    }


}
