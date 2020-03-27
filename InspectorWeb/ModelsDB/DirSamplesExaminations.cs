using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirSamplesExaminations
    {
        public DirSamplesExaminations()
        {
            DocsExaminationTasksExaminations = new HashSet<DocsExaminationTasksExaminations>();
        }

        public Guid Guid { get; set; }
        public Guid TypeGuid { get; set; }
        public string Title { get; set; }

        public virtual DirExaminations TypeGu { get; set; }
        public virtual ICollection<DocsExaminationTasksExaminations> DocsExaminationTasksExaminations { get; set; }
    }
}
