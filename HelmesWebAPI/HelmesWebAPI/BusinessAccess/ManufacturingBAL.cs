using HelmesWebAPI.Contract;
using HelmesWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelmesWebAPI.BusinessAccess
{
    public class ManufacturingBAL : IManufacturingIBAL
    {
        private readonly IManufacturingDAL manufacturingIDL;

        public ManufacturingBAL(IManufacturingDAL ManufacturingIDL)
        {
            manufacturingIDL = ManufacturingIDL;
        }

        public async Task<List<SectorList>> GetSectors()
        {
            return await manufacturingIDL.GetSectorsList();
        }

        public async Task<UserDetails> GetUserDetails(Guid sessionId)
        {
            return await manufacturingIDL.GetUserDetails(sessionId);
        }

        public async Task<bool> SaveInfo(UserDetails userDetails)
        {

            return await manufacturingIDL.SaveInfo(userDetails);
        }
    }
}
