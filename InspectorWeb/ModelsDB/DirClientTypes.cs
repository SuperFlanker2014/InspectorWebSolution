using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirClientTypes
    {
        public DirClientTypes()
        {
            DocsClients = new HashSet<DocsClients>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DocsClients> DocsClients { get; set; }
    }
}
