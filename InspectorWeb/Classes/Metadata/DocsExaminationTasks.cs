using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace InspectorWeb.ModelsDB
{
	[ModelMetadataType(typeof(MetaData))]
	public partial class DocsExaminationTasks : IModelBase
	{
		[DisplayName("Задания на исследование")]
		public class MetaData
		{
			[DisplayName("Номер")] public int? Number { get; set; }
			[DisplayName("Дата")] public DateTime? Date { get; set; }
		}
	}
}