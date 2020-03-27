using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirExaminationMethods
    {
        public DirExaminationMethods()
        {
            DocsExaminationTasksExaminations = new HashSet<DocsExaminationTasksExaminations>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DocsExaminationTasksExaminations> DocsExaminationTasksExaminations { get; set; }
    }
}
