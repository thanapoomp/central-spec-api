using System.Collections.Generic;
using System.Threading.Tasks;
using CentralSpecAPI.DTOs.Product;
using CentralSpecAPI.Models;
using CentralSpecAPI.Models.ClientVersion;
using CentralSpecAPI.DTOs.ClientVersion;

namespace CentralSpecAPI.Services.ClientVersion
{
    public interface IClientVersionService
    {
        Task<ServiceResponse<Models.ClientVersion.ClientVersion>> AddClientVersion(ClientVersionDtoToAdd input);

        Task<ServiceResponse<List<Models.ClientVersion.ClientVersion>>> GetAllClientVersion();

        Task<ServiceResponse<Models.ClientVersion.ClientVersion>> GetLastClientVersion();
    }
}
