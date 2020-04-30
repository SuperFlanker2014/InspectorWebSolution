using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using InspectorWeb.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace InspectorWeb.Controllers
{
	public class CommonController : BaseController
	{
		public IActionResult RaiseError()
		{
			throw new Exception();
		}

		public IActionResult Error()
		{
			var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

			//if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
			//{
			//	ExceptionMessage = "File error thrown";
			//}
			//if (exceptionHandlerPathFeature?.Path == "/index")
			//{
			//	ExceptionMessage += " from home page";
			//}

			var view = new ErrorViewModel
			{
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
				StackTrace = exceptionHandlerPathFeature.Error.StackTrace
			};

			return View(view);
		}
	}
}