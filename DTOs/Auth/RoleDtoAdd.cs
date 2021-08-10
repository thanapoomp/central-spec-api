using CentralSpecAPI.Validations;

namespace CentralSpecAPI.DTOs
{
    public class RoleDtoAdd
    {
        [FirstLetterUpperCase]
        public string RoleName { get; set; }
    }
}