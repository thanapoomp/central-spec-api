using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CentralSpecAPI.Models.Base;

namespace CentralSpecAPI.Models.Material
{
    [Table("Unit", Schema = "material")]
    public class Unit : StandardFields
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public bool IsActive { get; set; }


    }
}