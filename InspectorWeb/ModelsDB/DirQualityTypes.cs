using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirQualityTypes
    {
        public DirQualityTypes()
        {
            DocsConclusionsImport = new HashSet<DocsConclusionsImport>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DocsConclusionsImport> DocsConclusionsImport { get; set; }
    }
}
