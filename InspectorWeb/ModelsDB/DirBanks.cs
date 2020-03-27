using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirBanks
    {
        public DirBanks()
        {
            DocsClients = new HashSet<DocsClients>();
        }

        public Guid Guid { get; set; }
        public string Adress { get; set; }
        public string Bik { get; set; }
        public string CorrAcc { get; set; }
        public string Title { get; set; }
        public string City { get; set; }

        public virtual ICollection<DocsClients> DocsClients { get; set; }
    }
}
