using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class SecObjects
    {
        public SecObjects()
        {
            SecAccessMatrix = new HashSet<SecAccessMatrix>();
        }

        public Guid Guid { get; set; }
        public Guid? ObjectGuid { get; set; }
        public Guid? TypeGuid { get; set; }
        public string Title { get; set; }

        public virtual SecAppObjects ObjectGu { get; set; }
        public virtual SecAppObjectsTypes TypeGu { get; set; }
        public virtual ICollection<SecAccessMatrix> SecAccessMatrix { get; set; }
    }
}
