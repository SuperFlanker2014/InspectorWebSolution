using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsGoods
    {
        public DocsGoods()
        {
            DocsGoodsDiseases = new HashSet<DocsGoodsDiseases>();
        }

        public Guid Guid { get; set; }
        public Guid DocGuid { get; set; }
        public Guid GoodGuid { get; set; }
        public Guid ProductionCountryGuid { get; set; }
        public int? Places { get; set; }
        public Guid? PlacesUnitGuid { get; set; }
        public decimal? Weight { get; set; }
        public Guid? WeightUnitGuid { get; set; }
        public int? SamplesCount { get; set; }

        public virtual ICollection<DocsGoodsDiseases> DocsGoodsDiseases { get; set; }
    }
}
