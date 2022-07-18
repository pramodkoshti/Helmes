using HelmesWebAPI.BusinessAccess;
using HelmesWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelmesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturingController : ControllerBase
    {      
        private readonly ILogger<ManufacturingController> _logger;
        private readonly IManufacturingIBAL manufacturingRepositoryIBL;

        public ManufacturingController(ILogger<ManufacturingController> logger, IManufacturingIBAL ManufacturingRepositoryIBL)
        {
            _logger = logger;
            manufacturingRepositoryIBL = ManufacturingRepositoryIBL;
        }

        [HttpGet("GetSectors")]
        public async Task<List<SectorList>> GetSectorLists() 
        {
            return await manufacturingRepositoryIBL.GetSectors();
        }

        [HttpGet("UserDetails")]
        public async Task<UserDetails> GetUserDetails(Guid sessionId)
        {
            return await manufacturingRepositoryIBL.GetUserDetails(sessionId);
        }

        [HttpPost]
        public async Task<bool> SaveInfo(UserDetails userDetails)
        {
            return await manufacturingRepositoryIBL.SaveInfo(userDetails);
        }

    }
}
