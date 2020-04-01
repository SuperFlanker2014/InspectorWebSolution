using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InspectorWeb.Components
{
	public class TasksCiphersGrid : ViewComponent
	{
		public TasksCiphersGrid()
		{

		}

		public IViewComponentResult Invoke()
		{
			return View("TasksCiphersGrid");
		}
	}
}