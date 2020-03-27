using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirServicesGroups
    {
        public DirServicesGroups()
        {
            DirServices = new HashSet<DirServices>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }
        public decimal Factor { get; set; }

        public virtual ICollection<DirServices> DirServices { get; set; }
    }
}
