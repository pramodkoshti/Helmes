using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelmesWebAPI.Model
{
    public class UserDetails
    {
        public string Username { get; set; }
        public string SectorsIds { get; set; }
        public bool IsAgreeToTerms { get; set; }
        public Guid SessionId { get; set; }
        public List<SectorList> UserSectors {get;set;}
    }
}
