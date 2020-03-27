using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DocsAgreements
    {
        public Guid Guid { get; set; }
        public DateTime DateLimit { get; set; }
        public string Subject { get; set; }

        public virtual DocsAll Gu { get; set; }
    }
}
