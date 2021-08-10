using System;
using System.ComponentModel.DataAnnotations;
using CentralSpecAPI.Models.Product;

namespace CentralSpecAPI.DTOs.Product
{
    public class GetProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Stock { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public int StatusId { get; set; }

        public int ProductGroupId { get; set; }

        public string ProductGroupName { get; set; }

        public GetProductGroupDto ProductGroup { get; set; }

        //public ProductGroup ProductGroup { get; set; }

        public bool IsActive { get; set; }

    }
}