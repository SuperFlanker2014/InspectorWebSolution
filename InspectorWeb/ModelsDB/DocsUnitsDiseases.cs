using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsUnitsDiseases
    {
        public Guid Guid { get; set; }
        public Guid DiaseaseGuid { get; set; }
        public string ExamMethod { get; set; }
        public int ExamCount { get; set; }

        public virtual DirDiseases DiaseaseGu { get; set; }
        public virtual DocsUnits Gu { get; set; }
    }
}
