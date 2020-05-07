using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;
using InspectorWeb.ViewModels;

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

			//string reqStr;
			//try
			//{
			//	//reqStr = JsonConvert.SerializeObject(HttpContext.Request,
			//	//Formatting.Indented, new JsonSerializerSettings
			//	//{
			//	//	ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			//	//	ContractResolver = new IgnoreErrorPropertiesResolver()
			//	//});
			//}
			//catch (Exception ex)
			//{
			//	throw;
			//}			

			var view = new ErrorViewModel
			{
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
				StackTrace = exceptionHandlerPathFeature.Error.StackTrace,
				Request = HttpContext.Request.QueryString.ToString(),
				Exception = exceptionHandlerPathFeature.Error.Message
			};

			return View(view);
		}
	}

	//public class IgnoreErrorPropertiesResolver : DefaultContractResolver
	//{

	//	protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
	//	{
	//		JsonProperty property = base.CreateProperty(member, memberSerialization);

	//		if (new string[]
	//		{
	//			"InputStream",
	//			"Filter",
	//			"Length",
	//			"Position",
	//			"ReadTimeout",
	//			"WriteTimeout",
	//			"LastActivityDate",
	//			"LastUpdatedDate",
	//			"Session"
	//		}.Contains(property.PropertyName))
	//		{
	//			property.Ignored = true;
	//		}
	//		return property;
	//	}
	//}
}