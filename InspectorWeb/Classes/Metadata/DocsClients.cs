using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace InspectorWeb.ModelsDB
{
	[ModelMetadataType(typeof(MetaData))]
	public partial class DocsClients : IModelBase
	{
		public string Title => Name;

		[DisplayName("Клиенты")]
		public class MetaData
		{
			//[Remote("IsPhoneOrEmail", "YourController", ErrorMessage = "Not a valid phone or e-mail!")]
			[DisplayName("Название"), Required(ErrorMessage = "Требуется Название")] public string Name { get; set; }
			[DisplayName("ИНН"), Required(ErrorMessage = "Требуется ИНН"), Inn(ErrorMessage = "Неправильный формат ИНН (10 или 12 цифр)")] public string Inn { get; set; }
			[DisplayName("КПП"), RegularExpression(@"\d{4}[\dA-Z][\dA-Z]\d{3}", ErrorMessage = "Неправильный формат КПП (9 цифр)")] public string Kpp { get; set; }
			[DisplayName("Адрес")] public string Adress { get; set; }
			[DisplayName("Адрес фактический")] public string AdressFact { get; set; }
			[DisplayName("Адрес склада")] public string AdressWarehouse { get; set; }
			[DisplayName("Телефон"), Phone] public string Phone { get; set; }
			[DisplayName("Представитель")] public string Representative { get; set; }
			[DisplayName("В лице")] public string FaceAgreement { get; set; }
			[DisplayName("Банковский счёт"), RegularExpression(@"\d{20}", ErrorMessage = "Неправильный формат номера счёта (20 цифр)")] public string BankAccount { get; set; }

			[DisplayName("Банк")] public DirBanks BankGu { get; set; }
			[DisplayName("Регион")] public DirCountries RegionGu { get; set; }			
			[DisplayName("Район")] public DirRegionsDistricts RegionRayonGu { get; set; }
			[DisplayName("Тип")] public DirClientTypes TypeGu { get; set; }

			[DisplayName("Банк")] public Guid BankGuid { get; set; }
			[DisplayName("Регион")] public Guid? RegionGuid { get; set; }
			[DisplayName("Район")] public Guid? RegionRayonGuid { get; set; }
			[DisplayName("Тип")] public Guid TypeGuid { get; set; }
		}
	}
}