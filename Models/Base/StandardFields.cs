using System;

namespace CentralSpecAPI.Models.Base
{
    public class StandardFields
    {

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}