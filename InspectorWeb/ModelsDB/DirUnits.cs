using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirUnits
    {
        public DirUnits()
        {
            DocsUnits = new HashSet<DocsUnits>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }
        public Guid GroupGuid { get; set; }

        public virtual DirUnitsGroups GroupGu { get; set; }
        public virtual ICollection<DocsUnits> DocsUnits { get; set; }
    }
}
