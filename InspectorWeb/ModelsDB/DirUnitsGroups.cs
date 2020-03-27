using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirUnitsGroups
    {
        public DirUnitsGroups()
        {
            DirUnits = new HashSet<DirUnits>();
            DirUnitsGroupsDiseases = new HashSet<DirUnitsGroupsDiseases>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DirUnits> DirUnits { get; set; }
        public virtual ICollection<DirUnitsGroupsDiseases> DirUnitsGroupsDiseases { get; set; }
    }
}
