using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsExaminationTasks
    {
        public DocsExaminationTasks()
        {
            DocsExaminationTasksCiphers = new HashSet<DocsExaminationTasksCiphers>();
            DocsExaminationTasksExaminations = new HashSet<DocsExaminationTasksExaminations>();
        }

        public Guid Guid { get; set; }
        public Guid? ClientId { get; set; }
        public string Title { get; set; }
        public string CountMassVolume { get; set; }
        public string SafePackage { get; set; }
        public DateTime? DateReceipt { get; set; }
        public DateTime? DateSampling { get; set; }
        public int? HasAppendix { get; set; }
        public bool? ShouldReturn { get; set; }
        public Guid? OriginCountryId { get; set; }
        public Guid? DestinationCountryId { get; set; }
        public string SamplingStandard { get; set; }
        public string SamplingPlace { get; set; }
        public string SamplingActor { get; set; }
        public Guid? SamplingProductionId { get; set; }
        public string ExamiationPlace { get; set; }
        public int? Number { get; set; }
        public DateTime? Date { get; set; }
        public Guid? AuthorId { get; set; }

        public virtual DirUsers Author { get; set; }
        public virtual DocsClients Client { get; set; }
        public virtual DirCountries DestinationCountry { get; set; }
        public virtual DirCountries OriginCountry { get; set; }
        public virtual DirGoods SamplingProduction { get; set; }
        public virtual ICollection<DocsExaminationTasksCiphers> DocsExaminationTasksCiphers { get; set; }
        public virtual ICollection<DocsExaminationTasksExaminations> DocsExaminationTasksExaminations { get; set; }
    }
}
