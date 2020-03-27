using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InspectorWeb.Classes
{
	public class VkTagHelper : TagHelper
	{
		//private const string address = "https://vk.com/metanit";

		//public override void Process(TagHelperContext context, TagHelperOutput output)
		//{
		//	output.TagName = "a";    // заменяет тег <vk> тегом <a>
		//							 // присваивает атрибуту href значение из address
		//	output.Attributes.SetAttribute("href", address);
		//	output.Content.SetContent("Группа в ВК");

		//	context.Items.

		//	//@(ViewData.ModelState.GetFieldValidationState("Name") == ModelValidationState.Invalid ? "block" : "none"); ">
		//}

		//public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		//{
		//	output.TagName = "div";
		//	// получаем вложенный контекст из дочерних tag-хелперов
		//	var target = await output.GetChildContentAsync();
		//	var content = "<h3>Социальные сети</h3>" + target.GetContent();
		//	output.Content.SetHtmlContent(content);
		//}
	}
}
