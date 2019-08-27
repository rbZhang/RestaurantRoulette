using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRoulette.Models
{
    public class SearchModel
    {
        public string MealType { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
