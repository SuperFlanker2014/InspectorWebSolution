using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace InspectorWeb.Controllers
{
	[Authorize]
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public class BaseController : Controller
	{
		public Guid UserGuid
		{
			get
			{
				if (Guid.TryParse(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value, out var userGuid))
				{
					return userGuid;
				}
				else
				{
					return Guid.Empty;
				}
			}
		}
	}
}