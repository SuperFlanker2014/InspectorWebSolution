using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsExaminationTasksExaminations
    {
        [NotMapped]
        public string ExamText
        {
            get
            {
                var title = this.Examination?.TypeGu?.Title;
                var n = $"{title.Substring(0, title.Length - 2)}ие";
                return n;
            }
        }
    }
}
