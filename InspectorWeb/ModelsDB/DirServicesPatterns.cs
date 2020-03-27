using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirServicesPatterns
    {
        public DirServicesPatterns()
        {
            DirServicesBillsPatterns = new HashSet<DirServicesBillsPatterns>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DirServicesBillsPatterns> DirServicesBillsPatterns { get; set; }
    }
}
