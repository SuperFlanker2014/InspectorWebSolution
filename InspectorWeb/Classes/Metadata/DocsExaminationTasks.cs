using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace InspectorWeb.ModelsDB
{
	[ModelMetadataType(typeof(MetaData))]
	public partial class DocsExaminationTasks : IModelBase
	{
		//public string Title => "";

		//public class MetaData
		//{
		//	//[Remote("IsPhoneOrEmail", "YourController", ErrorMessage = "Not a valid phone or e-mail!")]
		//	[DisplayName("Название"), Required(ErrorMessage = "Требуется Название")] public string Name { get; set; }
		//	[DisplayName("ИНН"), Required(ErrorMessage = "Требуется ИНН"), Inn(ErrorMessage = "Неправильный формат ИНН (10 или 12 цифр)")] public string Inn { get; set; }
		//	[DisplayName("КПП"), RegularExpression(@"\d{4}[\dA-Z][\dA-Z]\d{3}", ErrorMessage = "Неправильный формат КПП (9 цифр)")] public string Kpp { get; set; }
		//	[DisplayName("Банковский счёт"), RegularExpression(@"\d{20}", ErrorMessage = "Неправильный формат номера счёта (20 цифр)")] public string BankAccount { get; set; }
		//}

		/*
		public Guid Guid { get; set; }
        public Guid? ClientId { get; set; }
        public string Title { get; set; }

        public string CountMassVolume { get; set; }
        public string SafePackage { get; set; }
        public DateTime? DateReceipt { get; set; }
        public DateTime? DateSampling { get; set; }
        public int? HasAppendix { get; set; }
        public bool? ShouldReturn { get; set; }
        public Guid? OriginCountryId { get; set; }
        public Guid? DestinationCountryId { get; set; }
        public string SamplingStandard { get; set; }
        public string SamplingPlace { get; set; }
        public string SamplingActor { get; set; }
        public Guid? SamplingProduction { get; set; }
        public string ExamiationPlace { get; set; }

        public virtual DocsClients Client { get; set; }
        public virtual DirCountries DestinationCountry { get; set; }
        public virtual DirCountries OriginCountry { get; set; }
        public virtual DirGoods SamplingProductionNavigation { get; set; }
        public virtual ICollection<DocsExaminationTasksExaminations> DocsExaminationTasksExaminations { get; set; }
			 */

		[DisplayName("Задания на исследование")]
		public new class MetaData
		{
		//	[DisplayName("Транспорт №")] public string TransportNumber { get; set; }
		//	[DisplayName("Накладная №")] public string InvoiceNumber { get; set; }
		//	[DisplayName("от")] public DateTime? InvoiceDate { get; set; }
		//	[DisplayName("Сертификат")] public string SertNumber { get; set; }
		//	[DisplayName("выдан")] public string SertFrom { get; set; }
		//	[DisplayName("Откуда / куда")] public string TargetOrSource { get; set; }
		//	[DisplayName("Фактический адрес")] public string FactAddress { get; set; }
		//	[DisplayName("Карантинный сертификат")] public string KarantinSertNumber { get; set; }
		//	[DisplayName("от")] public DateTime? KarantinSertDate { get; set; }

		//	[DisplayName("Номер")] public Guid Guid { get; set; }
		//	[DisplayName("Тип накладной")] public Guid? InvoiceTypeGuid { get; set; }
		//	[DisplayName("Транспорт")] public Guid? TransportTypeGuid { get; set; }
		//	[DisplayName("Откуда / куда")] public Guid? TargetOrSourceGuid { get; set; }

		//	[DisplayName("Номер")] public DocsWithGoods Gu { get; set; }
		//	[DisplayName("Тип накладной")] public DirInvoiceTypes InvoiceTypeGu { get; set; }
		//	[DisplayName("Транспорт")] public DirTransportTypes TransportTypeGu { get; set; }
		//	[DisplayName("Откуда / куда")] public DirCountries TargetOrSourceGu { get; set; }
		}
	}
}