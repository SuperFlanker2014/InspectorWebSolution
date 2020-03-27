using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class SecAppObjects
    {
        public SecAppObjects()
        {
            SecObjects = new HashSet<SecObjects>();
        }

        public Guid Guid { get; set; }
        public Guid TypeGuid { get; set; }
        public string Name { get; set; }

        public virtual SecAppObjectsTypes TypeGu { get; set; }
        public virtual ICollection<SecObjects> SecObjects { get; set; }
    }
}
