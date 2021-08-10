using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CentralSpecAPI.DTOs.ClientVersion;
using CentralSpecAPI.Services.ClientVersion;

namespace CentralSpecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientVersionController : ControllerBase
    {
        private readonly IClientVersionService _clientVersionService;
        public ClientVersionController(IClientVersionService clientVersionService)
        {
            this._clientVersionService = clientVersionService;

        }

        [HttpPost("AddClientVersion")]
        public async Task<IActionResult> Add(ClientVersionDtoToAdd input)
        {
            var result = await _clientVersionService.AddClientVersion(input);
            return Ok(result);
        }

        [HttpGet("GetAllClientVersions")]
        public async Task<IActionResult> Get()
        {
            var result = await _clientVersionService.GetAllClientVersion();
            return Ok(result);
        }

        [HttpGet("GetLastClientVersion")]
        public async Task<IActionResult> GetLastVersion()
        {
            var result = await _clientVersionService.GetLastClientVersion();
            return Ok(result);
        }
    }
}


