using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirServicesSumFactors
    {
        public DirServicesSumFactors()
        {
            DocsBillsServices = new HashSet<DocsBillsServices>();
        }

        public Guid Guid { get; set; }
        public string TitleShort { get; set; }
        public decimal SumFactor { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DocsBillsServices> DocsBillsServices { get; set; }
    }
}
