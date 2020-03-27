using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirGoodsGroupsCategories
    {
        public DirGoodsGroupsCategories()
        {
            DirGoodsGroups = new HashSet<DirGoodsGroups>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DirGoodsGroups> DirGoodsGroups { get; set; }
    }
}
