using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsUnitsExaminations
    {
        public Guid Guid { get; set; }
        public Guid ExaminationGuid { get; set; }
        public decimal Volume { get; set; }

        public virtual DirExaminations ExaminationGu { get; set; }
        public virtual DocsUnits Gu { get; set; }
    }
}
