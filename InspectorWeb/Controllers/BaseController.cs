using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;
using Microsoft.AspNetCore.Authorization;

namespace InspectorWeb.Controllers
{
	[Authorize]
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public class BaseController : Controller
	{

	}
}