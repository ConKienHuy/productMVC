using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace productMVC.Models
{
    public class ProductDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Brand { get; set; } = "";
        [Required, MaxLength(100)]
        public string Category { get; set; } = "";
        [Required, Precision(16, 2)]
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public IFormFile ImageFileName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
