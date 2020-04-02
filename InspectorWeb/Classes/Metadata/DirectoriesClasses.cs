using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace InspectorWeb.ModelsDB
{
	[ModelMetadataType(typeof(MetaData))]
	public partial class DirBanks : IModelBase
	{
		[DisplayName("Банки")]
		public class MetaData
		{
			[DisplayName("Адрес")] public string Adress { get; set; }
			[DisplayName("БИК")] public string Bik { get; set; }
			[DisplayName("Счёт")] public string CorrAcc { get; set; }
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Город")] public string City { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirClientTypes : IModelBase
	{
		[DisplayName("Типы клиентов")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirCountries : IModelBase
	{
		[DisplayName("Страны и регионы")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Из")] public string In { get; set; }
			[DisplayName("В")] public string Out { get; set; }
			[DisplayName("Россия?")] public bool? IsRussia { get; set; }
			[DisplayName("Сертификат")] public string Sert { get; set; }
		}
	}
	
	[ModelMetadataType(typeof(MetaData))]
	public partial class DirDiaseasesStates : IModelBase
	{
		[DisplayName("Болезни (статусы)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirDiseases : IModelBase
	{
		[DisplayName("Болезни")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Название на латыни")] public string TitleLatin { get; set; }
			[DisplayName("Карантинный?")] public bool IsKarantin { get; set; }
			[DisplayName("Исследование")] public DirExaminations ExaminationGu { get; set; }
			[DisplayName("Группа")] public DirDiseasesGroups GroupGu { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirDiseasesGroups : IModelBase
	{
		[DisplayName("Болезни (группы)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirDiseasesCounts : IModelBase
	{
		[DisplayName("Болезни (единицы)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirExaminations : IModelBase
	{
		[DisplayName("Исследования")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirGoods : IModelBase
	{
		[DisplayName("Продукция")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Группа")] public DirGoodsGroups GroupGu { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirGoodsExams : IModelBase
	{
		[DisplayName("Продукция (исследования)")]
		public class MetaData
		{
			[DisplayName("Исследование")] public DirExaminations ExaminationGu { get; set; }
			[DisplayName("Группа")] public DirGoodsGroups GroupGu { get; set; }
		}

		[NotMapped]
		public string Title { get; set; }
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirGoodsGroups : IModelBase
	{
		[DisplayName("Продукция (группы)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Лес?")] public bool IsForest { get; set; }
			[DisplayName("Категория")] public DirGoodsGroupsCategories CategoryGu { get; set; }
			[DisplayName("Единица веса")] public DirWeightUnits WeightUnitGu { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirGoodsGroupsCategories : IModelBase
	{
		[DisplayName("Продукция (категории групп)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirInvoiceTypes : IModelBase
	{
		[DisplayName("Типы накладных")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirMarkTypes : IModelBase
	{
		[DisplayName("Типы отметок")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirObjectsCategories : IModelBase
	{
		[DisplayName("Категории объектов")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirOrganizations : IModelBase
	{
		[DisplayName("Организации")]
		public class MetaData
		{
			public Guid? ParentGuid { get; set; }
			public string RegionNumber { get; set; }
			public string DirectorDivKarantin { get; set; }
			public string Director { get; set; }
			public string Accountant { get; set; }
			[DisplayName("Название")] public string Title { get; set; }
			public string TitleShort { get; set; }
			public string Adress { get; set; }
			public string Telephone { get; set; }
			public string Fax { get; set; }
			public string Addressee { get; set; }
			public string BankTitle { get; set; }
			public decimal? BankCaccount { get; set; }
			public decimal? BankSaccount { get; set; }
			public string BankBik { get; set; }
			public string BankCity { get; set; }
			public string PaymentTarget { get; set; }
			public string AgreementNote { get; set; }
			public string Inn { get; set; }
			public decimal? Kpp { get; set; }
			public string PaymentAdressee { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirPlacesUnits : IModelBase
	{
		[DisplayName("Единицы мест")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirQualityTypes : IModelBase
	{
		[DisplayName("Типы качеств")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirRegionsDistricts : IModelBase
	{
		[DisplayName("Страны и регионы (районы)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Страна или регион")] public DirCountries RegionGu { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirSamplesActions : IModelBase
	{
		[DisplayName("Действия с образцами")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirServices : IModelBase
	{
		[DisplayName("Услуги")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Короткое название")] public string TitleShort { get; set; }
			[DisplayName("Цена")] public decimal Price { get; set; }
			[DisplayName("Группа")] public DirServicesGroups GroupGu { get; set; }
			[DisplayName("Единица")] public DirServicesUnits UnitGu { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirServicesBillsPatterns : IModelBase
	{
		[DisplayName("Услуги (связи шаблонов с услугами)")]
		public class MetaData
		{
			[DisplayName("Шаблон")] public DirServicesPatterns PatternGu { get; set; }
			[DisplayName("Услуга")] public DirServices ServiceGu { get; set; }
		}

		[NotMapped]
		public string Title { get; set; }
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirServicesGroups : IModelBase
	{
		[DisplayName("Услуги (группы)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Фактор")] public decimal Factor { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirServicesPatterns : IModelBase
	{
		[DisplayName("Услуги (шаблоны)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirServicesSumFactors : IModelBase
	{
		[DisplayName("Услуги (коэффициенты)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Короткое название")] public string TitleShort { get; set; }
			[DisplayName("Коэффициент")] public decimal SumFactor { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirServicesUnits : IModelBase
	{
		[DisplayName("Услуги (единицы измерения)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Код")] public string UnitCode { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirTextInspections : IModelBase
	{
		[DisplayName("Способы обследования")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirTextObjectTargetType : IModelBase
	{
		[DisplayName("Цели обследования объектов")]
		public class MetaData
		{
			[DisplayName("Текст")] public string Text { get; set; }
		}

		[NotMapped]
		public string Title
		{
			get { return Text; }
			set { Text = value; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirTextSamplesSourceTypes : IModelBase
	{
		[DisplayName("Источники образцов")]
		public class MetaData
		{
			[DisplayName("Текст")] public string Text { get; set; }
		}

		[NotMapped]
		public string Title
		{
			get { return Text; }
			set { Text = value; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirTextVerdictPatterns : IModelBase
	{
		[DisplayName("Карантинное состояние")]
		public class MetaData
		{
			[DisplayName("Текст")] public string Text { get; set; }
		}

		[NotMapped]
		public string Title
		{
			get { return Text; }
			set { Text = value; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirTextWoodCompositions : IModelBase
	{
		[DisplayName("Лес")]
		public class MetaData
		{
			[DisplayName("Текст")] public string Text { get; set; }
			[DisplayName("Вид")] public bool? IsKind { get; set; }
			[DisplayName("Доска")] public bool? IsBoard { get; set; }
			[DisplayName("Древесина")] public bool? IsTimber { get; set; }
		}

		[NotMapped]
		public string Title
		{
			get { return Text; }
			set { Text = value; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirTransportTypes : IModelBase
	{
		[DisplayName("Способы транспортировки")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirUnits : IModelBase
	{
		[DisplayName("Единицы измерения")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Группа")] public DirUnitsGroups GroupGu { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirUnitsGroups : IModelBase
	{
		[DisplayName("Единицы измерения (группы)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirUnitsGroupsDiseases : IModelBase
	{
		[DisplayName("Единицы измерения (группы и болезни)")]
		public class MetaData
		{
			[DisplayName("Болезнь")] public DirDiseases DiseaseGu { get; set; }
			[DisplayName("Группа")] public DirUnitsGroups GroupGu { get; set; }
		}

		[NotMapped]
		public string Title { get; set; }
	}
	
	[ModelMetadataType(typeof(MetaData))]
	public partial class DirWeightUnits : IModelBase
	{
		[DisplayName("Единицы веса")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Группировка")] public string Mnemonic { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirSamplesExaminations : IModelBase
	{
		[DisplayName("Испытания (показатели)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
			[DisplayName("Тип экспертизы")] public DirExaminations TypeGu { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirExaminationMethods : IModelBase
	{
		[DisplayName("Испытания (методики)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirUsers : IModelBase
	{
		[DisplayName("Пользователи")]
		public class MetaData
		{
			[DisplayName("Имя")] public string Name { get; set; }
			[DisplayName("Администратор")] public bool IsAdmin { get; set; }
			[DisplayName("Лаборатория")] public DirLaboratories Laboratory { get; set; }
			[DisplayName("Организация")] public DirOrganizations OrgGu { get; set; }
			[DisplayName("Логин")] public string Login { get; set; }
			[DisplayName("Пароль")] public string PasswordHash { get; set; }
		}

		[NotMapped]
		public string Title
		{
			get
			{
				return Name;
			}
			set
			{
				Name = value;
			}
		}
	}

	[ModelMetadataType(typeof(MetaData))]
	public partial class DirLaboratories : IModelBase
	{
		[DisplayName("Испытания (лаборатории)")]
		public class MetaData
		{
			[DisplayName("Название")] public string Title { get; set; }
		}
	}
}