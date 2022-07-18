using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelmesWebAPI.Model;

namespace HelmesWebAPI.Contract
{
    public interface IManufacturingDAL
    {
         Task<List<SectorList>> GetSectorsList();

         Task<bool> SaveInfo(UserDetails userDetails);

        Task<UserDetails> GetUserDetails(Guid sessionId);
    }
}
