using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class CreateDishDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Precision(6, 2)]
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
    }
}