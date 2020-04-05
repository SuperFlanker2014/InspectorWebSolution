using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InspectorWeb.Controllers
{
	[Route("api/data/DocsExaminationTasks")]
	public class DocsExaminationTasksDataController : BaseDataController<DocsExaminationTasks>
	{
		public DocsExaminationTasksDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}

		protected override IQueryable<DocsExaminationTasks> ResultIncludes(IQueryable<DocsExaminationTasks> r)
		{
			return r
				.Include(d => d.Author).ThenInclude(d => d.OrgGu).AsQueryable();
		}
	}	
}