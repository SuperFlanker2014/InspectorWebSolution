using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsGoodsDiseases
    {
        public Guid Guid { get; set; }
        public Guid DiaseaseGuid { get; set; }
        public decimal? Count { get; set; }
        public Guid? CountGuid { get; set; }
        public Guid? DiaseaseStateGuid { get; set; }

        public virtual DirDiseasesCounts CountGu { get; set; }
        public virtual DirDiseases DiaseaseGu { get; set; }
        public virtual DirDiaseasesStates DiaseaseStateGu { get; set; }
        public virtual DocsGoods Gu { get; set; }
    }
}
