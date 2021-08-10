using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CentralSpecAPI.Models.Base;

namespace CentralSpecAPI.Models.ClientVersion
{
    [Table("Version", Schema = "client")]
    public class ClientVersion : StandardFields
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Version { get; set; }

        [Required]
        public string Remark { get; set; }


    }
}