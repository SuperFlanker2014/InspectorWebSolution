using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InspectorWeb.ViewModels;
using InspectorWeb.ModelsDB;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InspectorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly InspectorWebDBContext context;
        private readonly IMapper mapper;

        public HomeController(InspectorWebDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
	}
}