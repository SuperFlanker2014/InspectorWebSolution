using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InspectorWeb.Classes
{
    public static class AttributesUtils
    {
		//public static T GetAttributeFrom<T>(this Type instanceType) where T : Attribute
		//{
		//	var attrType = typeof(T);
		//	return (T)instanceType.GetCustomAttributes(attrType, false).First();
		//}

		//public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
		//{
		//	var attrType = typeof(T);
		//	var property = instance.GetType().GetProperty(propertyName);
		//	return (T)property.GetCustomAttributes(attrType, false).First();
		//}

		public static string DisplayName(this Type instance, string propertyName)
		{
			var propertyValue = instance
				.GetCustomAttribute<ModelMetadataTypeAttribute>()?.MetadataType
				.GetProperty(propertyName)?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? propertyName;

			return propertyValue ?? string.Empty;
		}
	}
}
