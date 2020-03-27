using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirOrganizations
    {
        public DirOrganizations()
        {
            DirUsers = new HashSet<DirUsers>();
            InverseParentGu = new HashSet<DirOrganizations>();
            SecSubjects = new HashSet<SecSubjects>();
        }

        public Guid Guid { get; set; }
        public Guid? ParentGuid { get; set; }
        public string RegionNumber { get; set; }
        public string DirectorDivKarantin { get; set; }
        public string Director { get; set; }
        public string Accountant { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Addressee { get; set; }
        public string BankTitle { get; set; }
        public decimal? BankCaccount { get; set; }
        public decimal? BankSaccount { get; set; }
        public string BankBik { get; set; }
        public string BankCity { get; set; }
        public string PaymentTarget { get; set; }
        public string AgreementNote { get; set; }
        public string Inn { get; set; }
        public decimal? Kpp { get; set; }
        public string PaymentAdressee { get; set; }

        public virtual DirOrganizations ParentGu { get; set; }
        public virtual ICollection<DirUsers> DirUsers { get; set; }
        public virtual ICollection<DirOrganizations> InverseParentGu { get; set; }
        public virtual ICollection<SecSubjects> SecSubjects { get; set; }
    }
}
