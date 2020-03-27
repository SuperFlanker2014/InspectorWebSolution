using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirGoodsGroups
    {
        public DirGoodsGroups()
        {
            DirGoods = new HashSet<DirGoods>();
            DirGoodsExams = new HashSet<DirGoodsExams>();
        }

        public Guid Guid { get; set; }
        public Guid? CategoryGuid { get; set; }
        public string Title { get; set; }
        public Guid? WeightUnitGuid { get; set; }
        public bool IsForest { get; set; }

        public virtual DirGoodsGroupsCategories CategoryGu { get; set; }
        public virtual DirWeightUnits WeightUnitGu { get; set; }
        public virtual ICollection<DirGoods> DirGoods { get; set; }
        public virtual ICollection<DirGoodsExams> DirGoodsExams { get; set; }
    }
}
