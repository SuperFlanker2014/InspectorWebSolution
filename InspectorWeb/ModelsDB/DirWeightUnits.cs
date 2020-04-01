using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirWeightUnits
    {
        public DirWeightUnits()
        {
            DirGoodsGroups = new HashSet<DirGoodsGroups>();
            DocsExaminationTasksCiphers = new HashSet<DocsExaminationTasksCiphers>();
            DocsGoods = new HashSet<DocsGoods>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Mnemonic { get; set; }

        public virtual ICollection<DirGoodsGroups> DirGoodsGroups { get; set; }
        public virtual ICollection<DocsExaminationTasksCiphers> DocsExaminationTasksCiphers { get; set; }
        public virtual ICollection<DocsGoods> DocsGoods { get; set; }
    }
}
