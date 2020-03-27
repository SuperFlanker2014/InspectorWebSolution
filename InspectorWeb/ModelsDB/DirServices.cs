using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirServices
    {
        public DirServices()
        {
            DirServicesBillsPatterns = new HashSet<DirServicesBillsPatterns>();
            DocsBillsServices = new HashSet<DocsBillsServices>();
        }

        public Guid Guid { get; set; }
        public Guid GroupGuid { get; set; }
        public Guid UnitGuid { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public decimal Price { get; set; }

        public virtual DirServicesGroups GroupGu { get; set; }
        public virtual DirServicesUnits UnitGu { get; set; }
        public virtual ICollection<DirServicesBillsPatterns> DirServicesBillsPatterns { get; set; }
        public virtual ICollection<DocsBillsServices> DocsBillsServices { get; set; }
    }
}
