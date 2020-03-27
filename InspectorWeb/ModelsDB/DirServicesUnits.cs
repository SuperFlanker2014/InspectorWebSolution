using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirServicesUnits
    {
        public DirServicesUnits()
        {
            DirServices = new HashSet<DirServices>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string UnitCode { get; set; }

        public virtual ICollection<DirServices> DirServices { get; set; }
    }
}
