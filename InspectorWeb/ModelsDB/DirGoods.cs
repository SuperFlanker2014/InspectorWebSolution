using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirGoods
    {
        public DirGoods()
        {
            DocsExaminationTasks = new HashSet<DocsExaminationTasks>();
            DocsGoods = new HashSet<DocsGoods>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }
        public Guid GroupGuid { get; set; }

        public virtual DirGoodsGroups GroupGu { get; set; }
        public virtual ICollection<DocsExaminationTasks> DocsExaminationTasks { get; set; }
        public virtual ICollection<DocsGoods> DocsGoods { get; set; }
    }
}
