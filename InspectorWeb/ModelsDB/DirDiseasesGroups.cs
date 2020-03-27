using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirDiseasesGroups
    {
        public DirDiseasesGroups()
        {
            DirDiseases = new HashSet<DirDiseases>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DirDiseases> DirDiseases { get; set; }
    }
}
