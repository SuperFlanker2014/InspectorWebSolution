using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirUnitsGroupsDiseases
    {
        public Guid Guid { get; set; }
        public Guid GroupGuid { get; set; }
        public Guid DiseaseGuid { get; set; }

        public virtual DirDiseases DiseaseGu { get; set; }
        public virtual DirUnitsGroups GroupGu { get; set; }
    }
}
