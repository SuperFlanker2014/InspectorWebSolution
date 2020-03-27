using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsExaminationTasksExaminations
    {
        public Guid Guid { get; set; }
        public Guid TaskId { get; set; }
        public Guid ExaminationId { get; set; }
        public Guid MethodId { get; set; }
        public string ExaminationResult { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid UserId { get; set; }
        public string Comments { get; set; }

        public virtual DirSamplesExaminations Examination { get; set; }
        public virtual DirExaminationMethods Method { get; set; }
        public virtual DocsExaminationTasks Task { get; set; }
        public virtual DirUsers User { get; set; }
    }
}
