using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsConclusionsExamination
    {
        public Guid Guid { get; set; }
        public Guid? TransportTypeGuid { get; set; }
        public string TransportNumber { get; set; }
        public Guid? InvoiceTypeGuid { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string SertNumber { get; set; }
        public string SertFrom { get; set; }
        public string TargetOrSource { get; set; }
        public string FactAddress { get; set; }
        public string KarantinSertNumber { get; set; }
        public DateTime? KarantinSertDate { get; set; }
        public Guid? TargetOrSourceGuid { get; set; }

        public virtual DocsWithGoods Gu { get; set; }
        public virtual DirInvoiceTypes InvoiceTypeGu { get; set; }
        public virtual DirCountries TargetOrSourceGu { get; set; }
        public virtual DirTransportTypes TransportTypeGu { get; set; }
    }
}
