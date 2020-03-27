using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirGoodsExams
    {
        public Guid Guid { get; set; }
        public Guid ExaminationGuid { get; set; }
        public Guid GroupGuid { get; set; }

        public virtual DirExaminations ExaminationGu { get; set; }
        public virtual DirGoodsGroups GroupGu { get; set; }
    }
}
