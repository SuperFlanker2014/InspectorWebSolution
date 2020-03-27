using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirCountries
    {
        public DirCountries()
        {
            DirRegionsDistricts = new HashSet<DirRegionsDistricts>();
            DocsClients = new HashSet<DocsClients>();
            DocsConclusionsExamination = new HashSet<DocsConclusionsExamination>();
            DocsExaminationTasksDestinationCountry = new HashSet<DocsExaminationTasks>();
            DocsExaminationTasksOriginCountry = new HashSet<DocsExaminationTasks>();
            DocsGoods = new HashSet<DocsGoods>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string In { get; set; }
        public string Out { get; set; }
        public bool? IsRussia { get; set; }
        public string Sert { get; set; }

        public virtual ICollection<DirRegionsDistricts> DirRegionsDistricts { get; set; }
        public virtual ICollection<DocsClients> DocsClients { get; set; }
        public virtual ICollection<DocsConclusionsExamination> DocsConclusionsExamination { get; set; }
        public virtual ICollection<DocsExaminationTasks> DocsExaminationTasksDestinationCountry { get; set; }
        public virtual ICollection<DocsExaminationTasks> DocsExaminationTasksOriginCountry { get; set; }
        public virtual ICollection<DocsGoods> DocsGoods { get; set; }
    }
}
