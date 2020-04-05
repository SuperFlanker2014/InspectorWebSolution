using System;
using System.Linq;
using System.Reflection;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;

namespace InspectorWeb.Controllers
{
	public class BaseDataController<T> : BaseController where T : class, IModelBase
	{
		private static DateTime nullDate = new DateTime(1970, 1, 1);

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
			var sortField = Request.Query["sortField"].ToString().ToLower();
			var sortOrder = Request.Query["sortOrder"].ToString().ToLower();

			var ks = keys
				.Select(k => new { k, item = k.Replace("[from]", "").Replace("[to]", "") })
				.GroupBy(o => o.item)
				.ToDictionary(o => o.Key, o => o.ToList());

			foreach (var key in ks.Keys)
			{
				var propertyName = Char.ToUpper(key[0]) + key.Substring(1);
				var propertyInfo = properties.FirstOrDefault(prop => prop.Name == propertyName);

				if (propertyInfo == null)
				{
					continue;
				}

				if (ks[key].Count == 1)
				{
					var val = Request.Query[key].ToString().ToLower();

					if (!string.IsNullOrEmpty(val))
					{
						if (propertyInfo.PropertyType == typeof(string))
						{
							result = result.Where($"{propertyName}.Contains(@0.val)", new { val });
						}
						else if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(int?))
						{
							result = result.Where($"{propertyName}.Equals(@0.val)", new { val = int.Parse(val) });
						}
						else if (propertyInfo.PropertyType == typeof(bool) || propertyInfo.PropertyType == typeof(bool?))
						{
							result = result.Where($"{propertyName}.Equals(@0.val)", new { val = bool.Parse(val) });
						}
						else if (propertyInfo.PropertyType == typeof(Guid) || propertyInfo.PropertyType == typeof(Guid?))
						{
							result = result.Where($"{propertyName}.Equals(@0.val)", new { val = Guid.Parse(val) });
						}
					}
				}
				else //date
				{
					var dateFromString = Request.Query[ks[key].First(s => s.k.Contains("[from]")).k].ToString();
					var dateToString = Request.Query[ks[key].First(s => s.k.Contains("[to]")).k].ToString();

					if (DateTime.TryParseExact(dateFromString, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateFrom)
						&& dateFrom != nullDate)
					{
						result = result.Where($"{propertyName} >= @0.dateFrom", new { dateFrom });
					}

					if (DateTime.TryParseExact(dateToString, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTo)
						&& dateTo != nullDate)
					{
						result = result.Where($"{propertyName} <= @0.dateTo", new { dateTo });
					}
				}
			}

			result = ResultIncludes(result);

			var itemsCount = result.Count();

			if (!string.IsNullOrWhiteSpace(sortField) && !string.IsNullOrWhiteSpace(sortOrder))
			{
				var orderByArg = sortOrder == "asc" ? sortField : $"{sortField} descending";
				result = result
					.OrderBy(orderByArg);
			}

			result = result
				.Skip((pageIndex == 0 ? 0 : pageIndex - 1) * pageSize)
				.Take(pageSize);

			//var f = MyNamespace.QueryableExtensions.ToSql(result);

			var resultArray = result.ToArray();

			return new { data = resultArray, itemsCount = itemsCount };
		}

		protected virtual IQueryable<T> ResultIncludes(IQueryable<T> r)
		{
			return r;
		}

		[HttpPost]
		public object Post(T item)
		{
			item.Guid = Guid.NewGuid();
			DataContext.Set<T>().Add(item);

			try
			{
				DataContext.SaveChanges();
			}
			catch (Exception ex)
			{
				throw;
			}

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

			try
			{
				DataContext.SaveChanges();
			}
			catch (Exception ex)
			{
				throw;
			}

			return editedItem;
		}

		[HttpDelete("{id}")]
		public object Delete(Guid id)
		{
			T item = DataContext.Set<T>().Find(id);

			if (item == null)
				return null;

			DataContext.Set<T>().Remove(item);

			try
			{
				DataContext.SaveChanges();
			}
			catch (Exception ex)
			{
				throw;
			}

			return null;
		}
	}
}

namespace MyNamespace
{
	using Microsoft.EntityFrameworkCore.Query.Internal;
	using System.Reflection;
	using Microsoft.EntityFrameworkCore.Storage;
	using Microsoft.EntityFrameworkCore.Query;

	public static class QueryableExtensions
	{
		private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

		private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");
		private static readonly FieldInfo QueryModelGeneratorField = typeof(QueryCompiler).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryModelGenerator");
		private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");
		private static readonly PropertyInfo DatabaseDependenciesField = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");

		public static string ToSql<TEntity>(this IQueryable<TEntity> query)
		{
			var queryCompiler = (QueryCompiler)QueryCompilerField.GetValue(query.Provider);
			var queryModelGenerator = (QueryModelGenerator)QueryModelGeneratorField.GetValue(queryCompiler);
			var queryModel = queryModelGenerator.ParseQuery(query.Expression);
			var database = DataBaseField.GetValue(queryCompiler);
			var databaseDependencies = (DatabaseDependencies)DatabaseDependenciesField.GetValue(database);
			var queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
			var modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
			modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
			var sql = modelVisitor.Queries.First().ToString();

			return sql;
		}
	}
}