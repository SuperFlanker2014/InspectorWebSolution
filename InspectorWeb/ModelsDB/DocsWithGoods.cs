using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsWithGoods
    {
        public DocsWithGoods()
        {
            DocsGoods = new HashSet<DocsGoods>();
        }

        public Guid Guid { get; set; }

        public virtual DocsAll Gu { get; set; }
        public virtual DocsActs DocsActs { get; set; }
        public virtual DocsConclusionsExamination DocsConclusionsExamination { get; set; }
        public virtual DocsConclusionsExport DocsConclusionsExport { get; set; }
        public virtual DocsConclusionsImport DocsConclusionsImport { get; set; }
        public virtual ICollection<DocsGoods> DocsGoods { get; set; }
    }
}
