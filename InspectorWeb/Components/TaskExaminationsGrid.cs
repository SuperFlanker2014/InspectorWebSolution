using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InspectorWeb.Components
{
	public class TaskExaminationsGrid : ViewComponent
	{
		public TaskExaminationsGrid()
		{

		}

		public IViewComponentResult Invoke()
		{
			return View("Grid");
		}
	}
}