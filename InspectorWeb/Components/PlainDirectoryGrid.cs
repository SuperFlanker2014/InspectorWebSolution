using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InspectorWeb.Components
{
	public class PlainDirectoryGrid : ViewComponent
	{
		public PlainDirectoryGrid()
		{

		}

		public IViewComponentResult Invoke(InspectorWeb.ViewModels.PlainDirectoryModel model)
		{
			return View("Grid", model);
		}
	}
}
