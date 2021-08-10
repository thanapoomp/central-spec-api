using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralSpecAPI.DTOs.ClientVersion
{
    public class ClientVersionDtoToAdd
    {
        [Required]
        public string Version { get; set; }

        [Required]
        public string Remark { get; set; }

    }
}
