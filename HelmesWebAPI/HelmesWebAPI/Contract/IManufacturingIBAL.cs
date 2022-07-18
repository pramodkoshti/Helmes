using HelmesWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelmesWebAPI.BusinessAccess
{
    public interface IManufacturingIBAL
    {
        Task<List<SectorList>> GetSectors();

        Task<bool> SaveInfo(UserDetails userDetails);
        Task<UserDetails> GetUserDetails(Guid sessionId);
    }
}
