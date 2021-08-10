using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CentralSpecAPI.Data;
using CentralSpecAPI.Models;
using System.Linq.Dynamic.Core;
using CentralSpecAPI.DTOs.ClientVersion;

namespace CentralSpecAPI.Services.ClientVersion
{
    public class ClientVersionService : ServiceBase, IClientVersionService
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _dBContext;
        private readonly ILogger<ClientVersionService> _log;
        private readonly IHttpContextAccessor _httpContext;

        public ClientVersionService(IMapper mapper, IHttpContextAccessor httpContext, AppDBContext dBContext, ILogger<ClientVersionService> log) : base(dBContext, mapper, httpContext)
        {
            this._httpContext = httpContext;
            this._log = log;
            this._mapper = mapper;
            this._dBContext = dBContext;
        }

        public async Task<ServiceResponse<Models.ClientVersion.ClientVersion>> AddClientVersion(ClientVersionDtoToAdd input)
        {
            //validate clientVersion
            var clientVersionExsist = await _dBContext.ClientVersions.Where(x => x.Version == input.Version).AnyAsync();

            if (clientVersionExsist)
            {
                throw new Exception("Client version already exsist");
            }

            //Add clientVersion
            var itemToAdd = new Models.ClientVersion.ClientVersion();
            itemToAdd.Version = input.Version;
            itemToAdd.Remark = input.Remark;
            itemToAdd.UpdatedBy = Guid.Parse(GetUserId());
            itemToAdd.UpdatedDate = Now();

            await _dBContext.ClientVersions.AddAsync(itemToAdd);
            await _dBContext.SaveChangesAsync();

            return ResponseResult.Success(itemToAdd);
        }


        public async Task<ServiceResponse<List<Models.ClientVersion.ClientVersion>>> GetAllClientVersion()
        {
            var result = await _dBContext.ClientVersions.ToListAsync();

            return ResponseResult.Success(result);
        }

        public async Task<ServiceResponse<Models.ClientVersion.ClientVersion>> GetLastClientVersion()
        {
            var result = await _dBContext.ClientVersions.OrderByDescending(x => x.Id).FirstOrDefaultAsync();

            return ResponseResult.Success(result);
        }
    }
}
