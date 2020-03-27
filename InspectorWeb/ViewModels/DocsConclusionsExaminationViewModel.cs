using System;
using System.ComponentModel;
using InspectorWeb.ModelsDB;
using Newtonsoft.Json;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace InspectorWeb.ViewModels
{
	[DisplayName("Свидетельства экспертизы")]
	public class DocsConclusionsExaminationViewModel
	{
		public Guid Guid { get; set; }
		public Guid? UserGuid { get; set; }
		public Guid? ClientGuid { get; set; }

		[DisplayName("Номер")] public string Number { get; set; }
		[DisplayName("Дата"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")] public DateTime? Date { get; set; }
		
		[DisplayName("Транспорт")] public Guid? TransportTypeGuid { get; set; }
		[DisplayName("№")] public string TransportNumber { get; set; }
		[DisplayName("Накладная")] public Guid? InvoiceTypeGuid { get; set; }
		[DisplayName("№")] public string InvoiceNumber { get; set; }
		[DisplayName("от"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")] public DateTime? InvoiceDate { get; set; }
		[DisplayName("Сертификат")] public string SertNumber { get; set; }
		[DisplayName("выдан")] public string SertFrom { get; set; }
		[DisplayName("Откуда / куда")] public string TargetOrSource { get; set; }
		[DisplayName("Фактический адрес")] public string FactAddress { get; set; }
		[DisplayName("Карантинный сертификат")] public string KarantinSertNumber { get; set; }
		[DisplayName("от"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")] public DateTime? KarantinSertDate { get; set; }
		[DisplayName("Откуда / куда")] public Guid? TargetOrSourceGuid { get; set; }

		public string Goods { get; set; }

		public DocsGoodsViewModel[] DocsGoods
		{
			get { return Goods == null ? null : JsonConvert.DeserializeObject<DocsGoodsViewModel[]>(Goods); }
			set { Goods = JsonConvert.SerializeObject(value); }
		}

		public DocsConclusionsExaminationViewModel()
		{

		}

		public DocsConclusionsExaminationViewModel(DocsConclusionsExamination docsConclusionsExamination)
		{
			Guid = docsConclusionsExamination.Guid;

			UserGuid = Guid.Parse("081ed3f8-6d6e-45f4-8d29-5d05f6d92703");
			ClientGuid = Guid.Parse("7cd7504d-ea7b-4264-b0d0-004929bd8d51");
			Number = docsConclusionsExamination.Gu.Gu.Number;
			Date = docsConclusionsExamination.Gu.Gu.Date;
			
			DocsGoods = docsConclusionsExamination.Gu.DocsGoods.Select(m => new DocsGoodsViewModel(){
				Guid = m.Guid,
				DocGuid = m.DocGuid,
				GoodGuid = m.GoodGuid,
				ProductionCountryGuid = m.ProductionCountryGuid,
				Places = m.Places,
				PlacesUnitGuid = m.PlacesUnitGuid,
				Weight = m.Weight,
				WeightUnitGuid = m.WeightUnitGuid,
				SamplesCount = m.SamplesCount,
				Diseases = m.DocsGoodsDiseases.Select(m1 => new DocsGoodsDiseasesViewModel() {
					Guid = m1.Guid, Count = m1.Count, CountGuid = m1.CountGuid, DiaseaseGuid = m1.DiaseaseGuid, DiaseaseStateGuid = m1.DiaseaseStateGuid
				}).ToArray()
			}).ToArray();
			
			TransportTypeGuid = docsConclusionsExamination.TransportTypeGuid;
			TransportNumber = docsConclusionsExamination.TransportNumber;
			InvoiceTypeGuid = docsConclusionsExamination.InvoiceTypeGuid;
			InvoiceNumber = docsConclusionsExamination.InvoiceNumber;
			InvoiceDate = docsConclusionsExamination.InvoiceDate;
			SertNumber = docsConclusionsExamination.SertNumber;
			SertFrom = docsConclusionsExamination.SertFrom;
			TargetOrSource = docsConclusionsExamination.TargetOrSource;
			FactAddress = docsConclusionsExamination.FactAddress;
			KarantinSertNumber = docsConclusionsExamination.KarantinSertNumber;
			KarantinSertDate = docsConclusionsExamination.KarantinSertDate;
			TargetOrSourceGuid = docsConclusionsExamination.TargetOrSourceGuid;
		}
	}
}