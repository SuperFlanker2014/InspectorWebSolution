using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirLaboratories
    {
        public DirLaboratories()
        {
            DirUsers = new HashSet<DirUsers>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DirUsers> DirUsers { get; set; }
    }
}
