using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CentralSpecAPI.Models.Base;

namespace CentralSpecAPI.Models.Product
{
    [Table("Product", Schema = "product")]
    public class Material : StandardFields
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Stock { get; set; }

        public int ProductGroupId { get; set; }

        public ProductGroup ProductGroup { get; set; }

        public bool IsActive { get; set; }

        public int StatusId { get; set; }

    }
}