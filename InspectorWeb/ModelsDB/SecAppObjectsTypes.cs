using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class SecAppObjectsTypes
    {
        public SecAppObjectsTypes()
        {
            SecAppObjects = new HashSet<SecAppObjects>();
            SecObjects = new HashSet<SecObjects>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SecAppObjects> SecAppObjects { get; set; }
        public virtual ICollection<SecObjects> SecObjects { get; set; }
    }
}
