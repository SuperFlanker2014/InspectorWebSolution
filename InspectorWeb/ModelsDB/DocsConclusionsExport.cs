using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsConclusionsExport
    {
        public Guid Guid { get; set; }
        public Guid? MarkGuid { get; set; }
        public Guid? TransportTypeGuid { get; set; }
        public string TransportNumber { get; set; }
        public Guid? InvoiceTypeGuid { get; set; }
        public string InvoicNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string SendingTo { get; set; }
        public string Addressee { get; set; }
        public string Disinfection { get; set; }
        public string SamplesDoc { get; set; }
        public string SamplesDocNumber { get; set; }
        public string SamplesDocDate { get; set; }
        public Guid? SamplesActionGuid { get; set; }
        public string Warehouse { get; set; }
        public string Inspection { get; set; }
        public string Verdict { get; set; }
        public string Representative { get; set; }
        public string WoodComposition { get; set; }
        public Guid? OriginDistrictGuid { get; set; }
        public string OriginText { get; set; }
        public string Remark { get; set; }
        public string FactAddress { get; set; }

        public virtual DocsWithGoods Gu { get; set; }
        public virtual DirInvoiceTypes InvoiceTypeGu { get; set; }
        public virtual DirMarkTypes MarkGu { get; set; }
        public virtual DirRegionsDistricts OriginDistrictGu { get; set; }
        public virtual DirSamplesActions SamplesActionGu { get; set; }
        public virtual DirTransportTypes TransportTypeGu { get; set; }
    }
}
