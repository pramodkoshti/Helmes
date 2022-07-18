using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelmesWebAPI.Model
{
    public class SectorList
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? Pid { get; set; }

        public bool isChecked { get; set; }
        public bool isPlanType { get; set; }

        public int claimId { get; set; }

    }
}
