using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CentralSpecAPI.Models.Base;

namespace CentralSpecAPI.Models.Material
{
    [Table("SubCategory", Schema = "material")]
    public class SubCategory : StandardFields
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }



    }
}