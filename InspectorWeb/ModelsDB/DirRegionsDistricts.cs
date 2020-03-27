using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirRegionsDistricts
    {
        public DirRegionsDistricts()
        {
            DocsClients = new HashSet<DocsClients>();
            DocsConclusionsExport = new HashSet<DocsConclusionsExport>();
            DocsConclusionsImport = new HashSet<DocsConclusionsImport>();
            DocsUnits = new HashSet<DocsUnits>();
        }

        public Guid Guid { get; set; }
        public string Title { get; set; }
        public Guid RegionGuid { get; set; }

        public virtual DirCountries RegionGu { get; set; }
        public virtual ICollection<DocsClients> DocsClients { get; set; }
        public virtual ICollection<DocsConclusionsExport> DocsConclusionsExport { get; set; }
        public virtual ICollection<DocsConclusionsImport> DocsConclusionsImport { get; set; }
        public virtual ICollection<DocsUnits> DocsUnits { get; set; }
    }
}
