using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InspectorWeb.ModelsDB
{
    public interface IModelBase
    {
		Guid Guid { get; set; }
		string Title { get; }
	}	
}
