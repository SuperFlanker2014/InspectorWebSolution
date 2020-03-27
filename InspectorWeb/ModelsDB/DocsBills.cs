using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsBills
    {
        public DocsBills()
        {
            DocsBillsServices = new HashSet<DocsBillsServices>();
        }

        public Guid Guid { get; set; }
        public bool BillType { get; set; }
        public decimal DocSum { get; set; }
        public decimal TaxNds { get; set; }
        public bool IsRussia { get; set; }
        public bool IsTransacted { get; set; }
        public string PaydocNum { get; set; }
        public DateTime? PaydocDate { get; set; }
        public bool IsCash { get; set; }
        public string FactAddress { get; set; }

        public virtual DocsAll Gu { get; set; }
        public virtual ICollection<DocsBillsServices> DocsBillsServices { get; set; }
    }
}
