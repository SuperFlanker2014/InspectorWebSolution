using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;

namespace InspectorWeb.Controllers
{
	public class BaseDataController<T> : Controller where T : class, IModelBase
	{
		private InspectorWebDBContext DataContext { get; }
		private IMapper Mapper;

		public BaseDataController(InspectorWebDBContext dataContext, IMapper mapper)
		{
			DataContext = dataContext;
			Mapper = mapper;
		}

		[HttpGet]
		public object Get()
		{
			var properties = typeof(T).GetProperties();

			IQueryable<T> result = DataContext.Set<T>();			

			var keys = Request.Query.Keys;

			int.TryParse(Request.Query["pageIndex"], out int pageIndex);
			int.TryParse(Request.Query["pageSize"], out int pageSize);
			//var pageIndex = int.Parse(Request.Query["pageIndex"]);
			//var pageSize = int.Parse(Request.Query["pageSize"]);
			var sortField = Request.Query["sortField"].ToString().ToLower();
			var sortOrder = Request.Query["sortOrder"].ToString().ToLower();

			foreach (var key in keys)
			{
				var val = Request.Query[key].ToString().ToLower();

				var propertyName = Char.ToUpper(key[0]) + key.Substring(1);
				var propertyInfo = properties.FirstOrDefault(prop => prop.Name == propertyName);

				if (propertyInfo == null)
				{
					continue;
				}

				result = result.Where(item =>
					string.IsNullOrEmpty(val) ||
					(propertyInfo.GetValue(item, null) ?? string.Empty).ToString().ToLower().Contains(val));
			}

			var itemsCount = result.Count();

			var propertyInfoForSort = properties.FirstOrDefault(p => p.Name.ToLower() == sortField);

			var resultArray = 
				(sortOrder == "desc" ? 
					result.OrderByDescending(i => propertyInfoForSort == null ? i.Title : propertyInfoForSort.GetValue(i, null)) : 
					result.OrderBy(i => propertyInfoForSort == null ? i.Title : propertyInfoForSort.GetValue(i, null)))
				.Skip((pageIndex - 1) * pageSize)
				.Take(pageSize).ToArray();

			return new { data = resultArray, itemsCount = itemsCount };
		}		

		[HttpPost]
		public object Post(T item)
		{
			item.Guid = Guid.NewGuid();
			DataContext.Set<T>().Add(item);
			DataContext.SaveChanges();

			return item;
		}

		[HttpPut("{id}")]
		public object Put(Guid id, T editedItem)
		{
			var item = DataContext.Set<T>().Find(id);

			if (item == null)
				return null;

			Mapper.Map(editedItem, item, typeof(T), typeof(T));

			DataContext.Entry(item).State = EntityState.Modified;
			DataContext.SaveChanges();

			return editedItem;
		}

		[HttpDelete("{id}")]
		public object Delete(Guid id)
		{
			T item = DataContext.Set<T>().Find(id);

			if (item == null)
				return null;

			DataContext.Set<T>().Remove(item);
			DataContext.SaveChanges();

			return null;
		}
	}
}