using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;

namespace InspectorWeb.Controllers
{
	[Route("api/data/DirBanks")]
	public class DirBanksDataController : BaseDataController<DirBanks>
	{
		public DirBanksDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirClientTypes")]
	public class DirClientTypesDataController : BaseDataController<DirClientTypes>
	{
		public DirClientTypesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirCountries")]
	public class DirCountriesDataController : BaseDataController<DirCountries>
	{
		public DirCountriesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirDiaseasesStates")]
	public class DirDiaseasesStatesDataController : BaseDataController<DirDiaseasesStates>
	{
		public DirDiaseasesStatesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirDiseases")]
	public class DirDiseasesDataController : BaseDataController<DirDiseases>
	{
		public DirDiseasesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirDiseasesGroups")]
	public class DirDiseasesGroupsDataController : BaseDataController<DirDiseasesGroups>
	{
		public DirDiseasesGroupsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirDiseasesCounts")]
	public class DirDiseasesCountsDataController : BaseDataController<DirDiseasesCounts>
	{
		public DirDiseasesCountsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirExaminations")]
	public class DirExaminationsDataController : BaseDataController<DirExaminations>
	{
		public DirExaminationsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirGoods")]
	public class DirGoodsDataController : BaseDataController<DirGoods>
	{
		public DirGoodsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirGoodsExams")]
	public class DirGoodsExamsDataController : BaseDataController<DirGoodsExams>
	{
		public DirGoodsExamsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirGoodsGroups")]
	public class DirGoodsGroupsDataController : BaseDataController<DirGoodsGroups>
	{
		public DirGoodsGroupsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirGoodsGroupsCategories")]
	public class DirGoodsGroupsCategoriesDataController : BaseDataController<DirGoodsGroupsCategories>
	{
		public DirGoodsGroupsCategoriesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirInvoiceTypes")]
	public class DirInvoiceTypesDataController : BaseDataController<DirInvoiceTypes>
	{
		public DirInvoiceTypesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirMarkTypes")]
	public class DirMarkTypesDataController : BaseDataController<DirMarkTypes>
	{
		public DirMarkTypesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirObjectsCategories")]
	public class DirObjectsCategoriesDataController : BaseDataController<DirObjectsCategories>
	{
		public DirObjectsCategoriesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirOrganizations")]
	public class DirOrganizationsDataController : BaseDataController<DirOrganizations>
	{
		public DirOrganizationsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirPlacesUnits")]
	public class DirPlacesUnitsDataController : BaseDataController<DirPlacesUnits>
	{
		public DirPlacesUnitsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirQualityTypes")]
	public class DirQualityTypesDataController : BaseDataController<DirQualityTypes>
	{
		public DirQualityTypesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirRegionsDistricts")]
	public class DirRegionsDistrictsDataController : BaseDataController<DirRegionsDistricts>
	{
		public DirRegionsDistrictsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirSamplesActions")]
	public class DirSamplesActionsDataController : BaseDataController<DirSamplesActions>
	{
		public DirSamplesActionsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirServices")]
	public class DirServicesDataController : BaseDataController<DirServices>
	{
		public DirServicesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirServicesBillsPatterns")]
	public class DirServicesBillsPatternsDataController : BaseDataController<DirServicesBillsPatterns>
	{
		public DirServicesBillsPatternsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirServicesGroups")]
	public class DirServicesGroupsDataController : BaseDataController<DirServicesGroups>
	{
		public DirServicesGroupsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirServicesPatterns")]
	public class DirServicesPatternsDataController : BaseDataController<DirServicesPatterns>
	{
		public DirServicesPatternsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirServicesSumFactors")]
	public class DirServicesSumFactorsDataController : BaseDataController<DirServicesSumFactors>
	{
		public DirServicesSumFactorsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirServicesUnits")]
	public class DirServicesUnitsDataController : BaseDataController<DirServicesUnits>
	{
		public DirServicesUnitsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirTextInspections")]
	public class DirTextInspectionsDataController : BaseDataController<DirTextInspections>
	{
		public DirTextInspectionsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirTextObjectTargetType")]
	public class DirTextObjectTargetTypeDataController : BaseDataController<DirTextObjectTargetType>
	{
		public DirTextObjectTargetTypeDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirTextSamplesSourceTypes")]
	public class DirTextSamplesSourceTypesDataController : BaseDataController<DirTextSamplesSourceTypes>
	{
		public DirTextSamplesSourceTypesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirTextVerdictPatterns")]
	public class DirTextVerdictPatternsDataController : BaseDataController<DirTextVerdictPatterns>
	{
		public DirTextVerdictPatternsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirTextWoodCompositions")]
	public class DirTextWoodCompositionsDataController : BaseDataController<DirTextWoodCompositions>
	{
		public DirTextWoodCompositionsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirTransportTypes")]
	public class DirTransportTypesDataController : BaseDataController<DirTransportTypes>
	{
		public DirTransportTypesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirUnits")]
	public class DirUnitsDataController : BaseDataController<DirUnits>
	{
		public DirUnitsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirUnitsGroups")]
	public class DirUnitsGroupsDataController : BaseDataController<DirUnitsGroups>
	{
		public DirUnitsGroupsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirUnitsGroupsDiseases")]
	public class DirUnitsGroupsDiseasesDataController : BaseDataController<DirUnitsGroupsDiseases>
	{
		public DirUnitsGroupsDiseasesDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}
	
	[Route("api/data/DirWeightUnits")]
	public class DirWeightUnitsDataController : BaseDataController<DirWeightUnits>
	{
		public DirWeightUnitsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirSamplesExaminations")]
	public class DirSamplesExaminationsDataController : BaseDataController<DirSamplesExaminations>
	{
		public DirSamplesExaminationsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirExaminationMethods")]
	public class DirExaminationMethodsDataController : BaseDataController<DirExaminationMethods>
	{
		public DirExaminationMethodsDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}

	[Route("api/data/DirUsers")]
	public class DirUsersDataController : BaseDataController<DirUsers>
	{
		public DirUsersDataController(InspectorWebDBContext dataContext, IMapper mapper) : base(dataContext, mapper)
		{
		}
	}
}