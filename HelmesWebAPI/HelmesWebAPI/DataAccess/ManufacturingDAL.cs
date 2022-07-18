using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelmesWebAPI.Model;
using HelmesWebAPI.Contract;
using HelmesWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace HelmesWebAPI.DataAccess
{
    public class ManufacturingDAL : IManufacturingDAL
    {
        private readonly HelmesContext helmesContext;

        public ManufacturingDAL(HelmesContext HelmesContext)
        {
            helmesContext = HelmesContext;
        }

        public async Task<List<SectorList>> GetSectorsList() 
        {
            var sectorList =  (from sector in helmesContext.Sectors
                             select new SectorList { ID = sector.ID, Description = sector.Description, Name = sector.Name, Pid = sector.Pid, isChecked = false, isPlanType =false , claimId = sector.ID }).ToListAsync();

            return await sectorList;
        }

        public async Task<UserDetails> GetUserDetails(Guid sessionId)
        {
            var userDetails = new UserDetails();
            var userInfo = await helmesContext.UserInfo.FirstOrDefaultAsync(x => x.SessionId == sessionId);

            var sectorList = (from sector in helmesContext.Sectors
                              select new SectorList { ID = sector.ID, Description = sector.Description, Name = sector.Name, Pid = sector.Pid, isChecked = false, isPlanType = false, claimId = sector.ID }).ToList();

            if (userInfo != null)
            {
                userDetails = new UserDetails()
                {
                    Username = userInfo.Username,
                    SessionId = userInfo.SessionId,
                    IsAgreeToTerms = userInfo.IsAgreeToTerms,
                    SectorsIds = userInfo.SectorsIds,                    
                };
                int[] sectors = Array.ConvertAll(userDetails.SectorsIds.Split(','), s => int.Parse(s));


                foreach (var sectorId in sectors)
                {
                    sectorList[sectorId - 1].isChecked = true;
                }

                userDetails.UserSectors = sectorList;

                return userDetails;
            }
            return null;
            
        }

        public async Task<bool> SaveInfo(UserDetails userDetails)
        {            

            var entity = helmesContext.UserInfo.FirstOrDefault(x => x.SessionId == userDetails.SessionId);

            if(entity != null)
            {
                entity.SectorsIds = userDetails.SectorsIds;
                entity.Username = userDetails.Username;
                entity.IsAgreeToTerms = userDetails.IsAgreeToTerms;
            }
            else
            {
                entity = new UserInfo();
                entity.SectorsIds = userDetails.SectorsIds;
                entity.Username = userDetails.Username;
                entity.IsAgreeToTerms = userDetails.IsAgreeToTerms;
                entity.SessionId = userDetails.SessionId;
                helmesContext.UserInfo.Add(entity);
            }

            var result =  await helmesContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
