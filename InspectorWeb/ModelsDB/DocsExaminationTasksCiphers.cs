using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsExaminationTasksCiphers
    {
        public Guid Guid { get; set; }
        public Guid TaskId { get; set; }
        public string Cipher { get; set; }
        public Guid? WeightUnitId { get; set; }
        public decimal? Count { get; set; }
        public string Comments { get; set; }
        public string SampleTitle { get; set; }

        public virtual DocsExaminationTasks Task { get; set; }
        public virtual DirWeightUnits WeightUnit { get; set; }
    }
}
