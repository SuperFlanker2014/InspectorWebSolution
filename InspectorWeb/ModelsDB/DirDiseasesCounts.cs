using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirDiseasesCounts
    {
        public DirDiseasesCounts()
        {
            DocsGoodsDiseases = new HashSet<DocsGoodsDiseases>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DocsGoodsDiseases> DocsGoodsDiseases { get; set; }
    }
}
