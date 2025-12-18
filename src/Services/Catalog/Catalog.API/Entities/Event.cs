using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Entities
{
    public class Event
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Venue is required")]
        public string Venue { get; set; }

        public DateTime Date { get; set; }

        [Range(0, 100000, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
    }
}