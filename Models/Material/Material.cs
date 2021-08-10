using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CentralSpecAPI.Models.Base;

namespace CentralSpecAPI.Models.Material
{
    [Table("Material", Schema = "material")]
    public class Material : StandardFields
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Model { get; set; }
        public string Usage { get; set; }
        public string Note { get; set; }

        public string PictureURL { get; set; }

        public double Price { get; set; }

        public bool IsActive { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }


    }
}