using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsConclusionsObjects
    {
        public DocsConclusionsObjects()
        {
            DocsUnits = new HashSet<DocsUnits>();
        }

        public Guid Guid { get; set; }
        public string Representative { get; set; }
        public string Verdict { get; set; }
        public string Conclusion { get; set; }
        public Guid CategoryGuid { get; set; }

        public virtual DirObjectsCategories CategoryGu { get; set; }
        public virtual DocsAll Gu { get; set; }
        public virtual ICollection<DocsUnits> DocsUnits { get; set; }
    }
}
