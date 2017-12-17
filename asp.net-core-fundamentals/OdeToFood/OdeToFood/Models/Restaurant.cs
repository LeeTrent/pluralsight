using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public Restaurant()
        {
        }

        public int Id { get; set; }

        [Display(Name="Restaurant Name")]
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } 

        [Required]
        public CuisineType Cuisine { get; set; }
    }
}
