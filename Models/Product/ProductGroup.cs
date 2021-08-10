using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CentralSpecAPI.Models.Base;

namespace CentralSpecAPI.Models.Product
{

    [Table("ProductGroup", Schema = "product")]
    public class ProductGroup : StandardFields
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public List<Material> Product { get; set; }

        public int StatusId { get; set; }

    }
}