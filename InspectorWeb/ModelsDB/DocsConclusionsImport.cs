using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsConclusionsImport
    {
        public Guid Guid { get; set; }
        public Guid? MarkGuid { get; set; }
        public Guid? TransportTypeGuid { get; set; }
        public string TransportNumber { get; set; }
        public Guid? InvoiceTypeGuid { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public Guid? QualityTypeGuid { get; set; }
        public string QualityNumber { get; set; }
        public string QualityDate { get; set; }
        public string Arrived { get; set; }
        public Guid? ArrivedDistrictGuid { get; set; }
        public string IkrNumber { get; set; }
        public string SertNumber { get; set; }
        public string SertFrom { get; set; }
        public string Sender { get; set; }
        public string Disinfection { get; set; }
        public string SamplesDoc { get; set; }
        public string SamplesDocNumber { get; set; }
        public string SamplesDocDate { get; set; }
        public Guid? SamplesActionGuid { get; set; }
        public string Warehouse { get; set; }
        public string Inspection { get; set; }
        public string Verdict { get; set; }
        public string Representative { get; set; }
        public string Remark { get; set; }
        public string FactAddress { get; set; }

        public virtual DirRegionsDistricts ArrivedDistrictGu { get; set; }
        public virtual DocsWithGoods Gu { get; set; }
        public virtual DirInvoiceTypes InvoiceTypeGu { get; set; }
        public virtual DirMarkTypes MarkGu { get; set; }
        public virtual DirQualityTypes QualityTypeGu { get; set; }
        public virtual DirSamplesActions SamplesActionGu { get; set; }
        public virtual DirTransportTypes TransportTypeGu { get; set; }
    }
}
