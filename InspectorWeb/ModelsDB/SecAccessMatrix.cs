using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class SecAccessMatrix
    {
        public Guid Guid { get; set; }
        public Guid SubjectGuid { get; set; }
        public Guid ObjectGuid { get; set; }
        public Guid OperationGuid { get; set; }
        public Guid PermissionGuid { get; set; }

        public virtual SecObjects ObjectGu { get; set; }
        public virtual SecOperations OperationGu { get; set; }
        public virtual SecPermissions PermissionGu { get; set; }
        public virtual SecSubjects SubjectGu { get; set; }
    }
}
