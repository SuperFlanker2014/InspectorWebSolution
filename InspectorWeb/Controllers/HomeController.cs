using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InspectorWeb.ViewModels;

namespace InspectorWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public IActionResult Viewer()
		{
            var report = new InspectorWeb.Reports.Docs_Bills_Post_add();
            report.DataSource = new List<g>
            {
                new g { sum = 5, unit = "111" },
                new g { sum = 15, unit = "222" },
                new g { sum = 25, unit = "333" },
            };
            return View(report);
		}

        public class g
        {
            public int sum { get; set; }
            public string unit { get; set; }
        }
	}
}