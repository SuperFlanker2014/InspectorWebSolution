using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class SecSubjects
    {
        public SecSubjects()
        {
            SecAccessMatrix = new HashSet<SecAccessMatrix>();
        }

        public Guid Guid { get; set; }
        public Guid? UserGuid { get; set; }
        public Guid? OrgGuid { get; set; }
        public string Title { get; set; }

        public virtual DirOrganizations OrgGu { get; set; }
        public virtual DirUsers UserGu { get; set; }
        public virtual ICollection<SecAccessMatrix> SecAccessMatrix { get; set; }
    }
}
