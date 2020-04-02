using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InspectorWeb.ViewModels;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes;
using InspectorWeb.Classes.Metadata;

namespace InspectorWeb.Controllers
{
	[Route("Directories/{directoryName?}")]
	public class DirectoriesController : BaseController
	{
		private InspectorWebDBContext DataContext { get; }
		private IMapper Mapper;

		public DirectoriesController(InspectorWebDBContext dataContext, IMapper mapper)
		{
			DataContext = dataContext;
			Mapper = mapper;
		}

		public IActionResult Index(string directoryName)
        {
			if (string.IsNullOrEmpty(directoryName) ||
				!DirectoriesList.Directories.Any(di => di.Name == directoryName))
			{
				return View("PlainDirectory", new PlainDirectoryModel()
				{
					DirectoryName = directoryName,
					Directories = DirectoriesList.Directories,				
				});
			}

			var directoryClass = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsClass && t.Name.ToLower() == directoryName.ToLower());

			if (directoryClass == null)
			{
				return Content(string.Empty);
			}

			ViewData["Title"] = DirectoriesList.Directories.FirstOrDefault(di => di.Name == directoryName).Title;

			var dataContextType = typeof(InspectorWebDBContext);

			//var metaDataType = Assembly.GetExecutingAssembly().GetType(directoryClass.FullName + "+MetaData");

			var properties1 = directoryClass.GetProperties()
				.Where(p => 
					TypeSelector(p.PropertyType) != null 
					&& p.CustomAttributes.All(ca => ca.AttributeType != typeof(NotMappedAttribute))
					)
				.Select(p => new Tuple<string, string, Type, string>(Char.ToLower(p.Name[0]) + p.Name.Substring(1), TypeSelector(p.PropertyType), p.PropertyType, p.Name))
				.ToList();

			var properties = new List<DirectoryProperty>();
			var directoryDropdowns = new Dictionary<string, string>();

			foreach (var item in properties1)
			{
				var name = item.Item1 + (item.Item2 == "select" ? (item.Item1.EndsWith("Gu") ? "id" : "Id" ) : string.Empty);

				if (item.Item2 == "select")
				{			
					directoryDropdowns.Add(name, item.Item3.Name);
				}

				properties.Add(new DirectoryProperty(name, directoryClass.DisplayName(item.Item4), item.Item2));
			}		
			
			return View("PlainDirectory", new PlainDirectoryModel()
			{
				DirectoryName = directoryName,
				Properties = properties,
				Directories = DirectoriesList.Directories,
				DirectoryDropdowns = directoryDropdowns,
				Access = DirectoryAccessRights.Delete | DirectoryAccessRights.Edit | DirectoryAccessRights.Insert
			});
        }

		private string TypeSelector(Type type)
		{
			if (typeof(string).Equals(type))
			{
				return "text";
			}
			else if (typeof(bool).Equals(type))
			{
				return "checkbox";
			}
			else if (typeof(bool?).Equals(type))
			{
				return "checkbox";
			}
			else if(typeof(IModelBase).IsAssignableFrom(type))
			{
				return "select";
			}
			else
			{
				return null;
			}
		}
	}
}