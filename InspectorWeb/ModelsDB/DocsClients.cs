using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsClients
    {
        public DocsClients()
        {
            DocsAll = new HashSet<DocsAll>();
            DocsExaminationTasks = new HashSet<DocsExaminationTasks>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Adress { get; set; }
        public string AdressFact { get; set; }
        public string AdressWarehouse { get; set; }
        public string Phone { get; set; }
        public Guid? RegionGuid { get; set; }
        public string Representative { get; set; }
        public Guid TypeGuid { get; set; }
        public string FaceAgreement { get; set; }
        public Guid BankGuid { get; set; }
        public string BankAccount { get; set; }
        public Guid? RegionRayonGuid { get; set; }

        public virtual DirBanks BankGu { get; set; }
        public virtual DirCountries RegionGu { get; set; }
        public virtual DirRegionsDistricts RegionRayonGu { get; set; }
        public virtual DirClientTypes TypeGu { get; set; }
        public virtual ICollection<DocsAll> DocsAll { get; set; }
        public virtual ICollection<DocsExaminationTasks> DocsExaminationTasks { get; set; }
    }
}
