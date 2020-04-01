using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;

namespace InspectorWeb.Controllers
{
	[Route("api/data/DocsExaminationTasks")]
	public class DocsExaminationTasksDataController : BaseDataController<DocsExaminationTasks>
	{
		public DocsExaminationTasksDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}	
}