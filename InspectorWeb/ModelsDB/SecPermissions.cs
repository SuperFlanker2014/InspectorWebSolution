using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class SecPermissions
    {
        public SecPermissions()
        {
            SecAccessMatrix = new HashSet<SecAccessMatrix>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SecAccessMatrix> SecAccessMatrix { get; set; }
    }
}
