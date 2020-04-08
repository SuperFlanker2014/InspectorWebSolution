using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
			[DisplayName("Автор")] public Guid? AuthorId { get; set; }
		}

		[NotMapped]
		public string AppendixX => HasAppendix.HasValue ? "V" : "X";

		[NotMapped]
		public string ShouldReturnX => ShouldReturn.HasValue && ShouldReturn.Value ? "V" : "X";

		[NotMapped]
		public string NumberText => $"{this.Author?.OrgGu?.RegionNumber}-{this.Author?.FilialNumber}-{Number}";

		[NotMapped]
		public string SafePackageText
		{
			get
			{
				var res = new List<string>();

				foreach (var cipher in DocsExaminationTasksCiphers)
				{
					res.Add($"с.п.№ {cipher.SafePackageNumber} - шифр {cipher.Cipher}");
				}

				return string.Join(", ", res);
			}
		}
	}
}