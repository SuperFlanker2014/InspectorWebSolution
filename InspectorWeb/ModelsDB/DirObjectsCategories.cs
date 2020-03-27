using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirObjectsCategories
    {
        public DirObjectsCategories()
        {
            DocsConclusionsObjects = new HashSet<DocsConclusionsObjects>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DocsConclusionsObjects> DocsConclusionsObjects { get; set; }
    }
}
