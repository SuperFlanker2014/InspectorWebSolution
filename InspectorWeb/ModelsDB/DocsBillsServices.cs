using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsBillsServices
    {
        public Guid Guid { get; set; }
        public Guid DocGuid { get; set; }
        public Guid ServiceGuid { get; set; }
        public Guid FactorGuid { get; set; }
        public decimal Count { get; set; }

        public virtual DocsBills DocGu { get; set; }
        public virtual DirServicesSumFactors FactorGu { get; set; }
        public virtual DirServices ServiceGu { get; set; }
    }
}
