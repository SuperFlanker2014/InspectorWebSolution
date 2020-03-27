using System;
using System.Collections.Generic;

namespace InspectorWeb.ModelsDB
{
    public partial class DirTextWoodCompositions
    {
        public Guid Guid { get; set; }
        public string Text { get; set; }
        public bool? IsKind { get; set; }
        public bool? IsBoard { get; set; }
        public bool? IsTimber { get; set; }
    }
}
