using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRoulette.Models
{
    public class SearchModel
    {
        public string mealType { get; set; }
        public double latitude { get; set; }
        public double longitutde { get; set; }
    }
}
