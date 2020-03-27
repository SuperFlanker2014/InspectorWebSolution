using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirServicesBillsPatterns
    {
        public Guid Guid { get; set; }
        public Guid PatternGuid { get; set; }
        public Guid ServiceGuid { get; set; }

        public virtual DirServicesPatterns PatternGu { get; set; }
        public virtual DirServices ServiceGu { get; set; }
    }
}
