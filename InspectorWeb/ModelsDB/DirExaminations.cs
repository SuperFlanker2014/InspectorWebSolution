using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirExaminations
    {
        public DirExaminations()
        {
            DirDiseases = new HashSet<DirDiseases>();
            DirGoodsExams = new HashSet<DirGoodsExams>();
            DirSamplesExaminations = new HashSet<DirSamplesExaminations>();
            DocsUnitsExaminations = new HashSet<DocsUnitsExaminations>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DirDiseases> DirDiseases { get; set; }
        public virtual ICollection<DirGoodsExams> DirGoodsExams { get; set; }
        public virtual ICollection<DirSamplesExaminations> DirSamplesExaminations { get; set; }
        public virtual ICollection<DocsUnitsExaminations> DocsUnitsExaminations { get; set; }
    }
}
