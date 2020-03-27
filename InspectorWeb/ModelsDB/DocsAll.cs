using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsAll
    {
        public DocsAll()
        {
            InverseDocParentGu = new HashSet<DocsAll>();
        }

        public Guid Guid { get; set; }
        public Guid? DocParentGuid { get; set; }
        public string Number { get; set; }
        public DateTime? Date { get; set; }
        public Guid DocUserGuid { get; set; }
        public Guid DocClientGuid { get; set; }

        public virtual DocsClients DocClientGu { get; set; }
        public virtual DocsAll DocParentGu { get; set; }
        public virtual DirUsers DocUserGu { get; set; }
        public virtual DocsAgreements DocsAgreements { get; set; }
        public virtual DocsBills DocsBills { get; set; }
        public virtual DocsConclusionsObjects DocsConclusionsObjects { get; set; }
        public virtual DocsWithGoods DocsWithGoods { get; set; }
        public virtual ICollection<DocsAll> InverseDocParentGu { get; set; }
    }
}
