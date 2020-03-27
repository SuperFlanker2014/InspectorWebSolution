using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsActs
    {
        public Guid Guid { get; set; }
        public string Laboratory { get; set; }
        public string ClientAdressWarehouse { get; set; }
        public string Representative { get; set; }

        public virtual DocsWithGoods Gu { get; set; }
    }
}
