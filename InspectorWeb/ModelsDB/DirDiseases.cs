using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirDiseases
    {
        public DirDiseases()
        {
            DirUnitsGroupsDiseases = new HashSet<DirUnitsGroupsDiseases>();
            DocsGoodsDiseases = new HashSet<DocsGoodsDiseases>();
            DocsUnitsDiseases = new HashSet<DocsUnitsDiseases>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string TitleLatin { get; set; }
        public bool IsKarantin { get; set; }
        public Guid GroupGuid { get; set; }
        public Guid ExaminationGuid { get; set; }

        public virtual DirExaminations ExaminationGu { get; set; }
        public virtual DirDiseasesGroups GroupGu { get; set; }
        public virtual ICollection<DirUnitsGroupsDiseases> DirUnitsGroupsDiseases { get; set; }
        public virtual ICollection<DocsGoodsDiseases> DocsGoodsDiseases { get; set; }
        public virtual ICollection<DocsUnitsDiseases> DocsUnitsDiseases { get; set; }
    }
}
