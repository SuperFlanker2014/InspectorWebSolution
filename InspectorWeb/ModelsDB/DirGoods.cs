using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirGoods
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public Guid GroupGuid { get; set; }

        public virtual DirGoodsGroups GroupGu { get; set; }
    }
}
