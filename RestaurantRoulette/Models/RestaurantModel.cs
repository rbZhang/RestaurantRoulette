using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRoulette.Models
{

    public class RestaurantWrapper
    {
        [JsonProperty("results_found")]
        public int NumberResults { get; set; }
        public List<Restaurants> Restaurants { get; set; }
    }

    public class Restaurants
    {
        public Restaurant Restaurant { get; set; }
    }

    public class Restaurant
    {
        public string Name { get; set; }

        public string Cuisines { get; set; }

        public string Timings { get; set; }

        [JsonProperty("average_cost_for_two")]
        public int Cost { get; set; }

        [JsonProperty("location")]
        public Location Locations { get; set; }

        [JsonProperty("phone_numbers")]
        public string PhoneNumber { get; set; }

        [JsonProperty("user_rating")]
        public Rating Ratings { get; set; }

        [JsonProperty("featured_image")]
        public string Thumbnail { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public class Location
        {
            public string Address { get; set; }
        }
        public class Rating
        {
            [JsonProperty("aggregate_rating")]
            public double AverageRating { get; set; }

            [JsonProperty("votes")]
            public int NumberReview { get; set; }
        }
    }


}
