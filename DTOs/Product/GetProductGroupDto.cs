using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CentralSpecAPI.DTOs.Product
{
    public class GetProductGroupDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StatusId { get; set; }

        public List<GetProductDto> Product { get; set; }

        public bool IsActive { get; set; }

    }
}