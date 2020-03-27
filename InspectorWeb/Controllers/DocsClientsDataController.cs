using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;

namespace InspectorWeb.Controllers
{
	[Route("api/data/DocsClients")]
	public class DocsClientsDataController : BaseDataController<DocsClients>
	{
		public DocsClientsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}	
}