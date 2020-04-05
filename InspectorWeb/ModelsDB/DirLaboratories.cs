using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirLaboratories
    {
        public DirLaboratories()
        {
            DirUsers = new HashSet<DirUsers>();
            DocsExaminationTasks = new HashSet<DocsExaminationTasks>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Mnemonic { get; set; }

        public virtual ICollection<DirUsers> DirUsers { get; set; }
        public virtual ICollection<DocsExaminationTasks> DocsExaminationTasks { get; set; }
    }
}
