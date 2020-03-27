using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsUnits
    {
        public DocsUnits()
        {
            DocsUnitsDiseases = new HashSet<DocsUnitsDiseases>();
            DocsUnitsExaminations = new HashSet<DocsUnitsExaminations>();
        }

        public Guid Guid { get; set; }
        public Guid DocGuid { get; set; }
        public Guid UnitGuid { get; set; }
        public int Count { get; set; }
        public decimal Volume { get; set; }
        public string VolumeUnit { get; set; }
        public Guid DistrictGuid { get; set; }
        public int ExamTrap { get; set; }
        public int ExamBait { get; set; }
        public int ExamDust { get; set; }
        public int? ExamSample { get; set; }

        public virtual DirRegionsDistricts DistrictGu { get; set; }
        public virtual DocsConclusionsObjects DocGu { get; set; }
        public virtual DirUnits UnitGu { get; set; }
        public virtual ICollection<DocsUnitsDiseases> DocsUnitsDiseases { get; set; }
        public virtual ICollection<DocsUnitsExaminations> DocsUnitsExaminations { get; set; }
    }
}
