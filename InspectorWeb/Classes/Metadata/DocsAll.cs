using InspectorWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;

namespace InspectorWeb.ModelsDB
{
	[ModelMetadataType(typeof(MetaData))]
	public partial class DocsAll
    {
		[DisplayName("Документы")]
		public class MetaData
		{
			[DisplayName("Guid")] public Guid Guid { get; set; }			
			[DisplayName("Номер")] public string Number { get; set; }
			[DisplayName("Дата")] public DateTime? Date { get; set; }

			[DisplayName("Родительский документ")] public Guid? DocParentGuid { get; set; }
			[DisplayName("Пользователь")] public Guid DocUserGuid { get; set; }
			[DisplayName("Клиент")] public Guid DocClientGuid { get; set; }

			[DisplayName("Родительский документ")] public DocsAll DocParentGu { get; set; }
			[DisplayName("Пользователь")] public DirUsers DocUserGu { get; set; }
			[DisplayName("Клиент")] public DocsClients DocClientGu { get; set; }

			//public DocsAgreements DocsAgreements { get; set; }
			//public DocsBills DocsBills { get; set; }
			//public DocsConclusionsObjects DocsConclusionsObjects { get; set; }
			//public DocsWithGoods DocsWithGoods { get; set; }
			//public ICollection<DocsAll> InverseDocParentGu { get; set; }
		}
	}
}