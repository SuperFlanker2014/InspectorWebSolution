using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirPlacesUnits
    {
        public DirPlacesUnits()
        {
            DocsGoods = new HashSet<DocsGoods>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DocsGoods> DocsGoods { get; set; }
    }
}
