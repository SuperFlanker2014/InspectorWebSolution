using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InspectorWeb.Components
{
	public class GoodsGrid : ViewComponent
	{
		public GoodsGrid()
		{

		}

		public IViewComponentResult Invoke()
		{
			return View("Grid");
		}
	}
}