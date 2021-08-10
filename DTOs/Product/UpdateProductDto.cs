using System.ComponentModel.DataAnnotations;

namespace CentralSpecAPI.DTOs.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Stock { get; set; }

        public int ProductGroupId { get; set; }

        public int StatusId { get; set; }

    }
}