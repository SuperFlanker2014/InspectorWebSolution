using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirUsers
    {
        public DirUsers()
        {
            DocsAll = new HashSet<DocsAll>();
            DocsExaminationTasksExaminations = new HashSet<DocsExaminationTasksExaminations>();
            SecSubjects = new HashSet<SecSubjects>();
        }

        public Guid OrgGuid { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int PasswordHash { get; set; }

        public virtual DirOrganizations OrgGu { get; set; }
        public virtual ICollection<DocsAll> DocsAll { get; set; }
        public virtual ICollection<DocsExaminationTasksExaminations> DocsExaminationTasksExaminations { get; set; }
        public virtual ICollection<SecSubjects> SecSubjects { get; set; }
    }
}
