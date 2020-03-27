using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirInvoiceTypes
    {
        public DirInvoiceTypes()
        {
            DocsConclusionsExamination = new HashSet<DocsConclusionsExamination>();
            DocsConclusionsExport = new HashSet<DocsConclusionsExport>();
            DocsConclusionsImport = new HashSet<DocsConclusionsImport>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DocsConclusionsExamination> DocsConclusionsExamination { get; set; }
        public virtual ICollection<DocsConclusionsExport> DocsConclusionsExport { get; set; }
        public virtual ICollection<DocsConclusionsImport> DocsConclusionsImport { get; set; }
    }
}
