using AutoMapper;
using AutoMapper.Configuration;
using InspectorWeb.ModelsDB;
using InspectorWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace InspectorWeb.Classes
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()	: this("InspectorWebProfile")
		{
		}
		
		protected AutoMapperProfile(string profileName) : base(profileName)
		{
			foreach (var type in DirectoriesList.DirectoriesTypes)
			{
				CreateMap(type, type);
			}		

			CreateMap<DocsGoodsDiseasesViewModel, DocsGoodsDiseases>();
			CreateMap<DocsGoodsViewModel, DocsGoods>()
				.ForMember(dce => dce.DocsGoodsDiseases, opt => opt.MapFrom(s => s.Diseases));
			CreateMap<DocsConclusionsExaminationViewModel, DocsAll>()				
				.ForMember(dce => dce.DocClientGu, opt => opt.Ignore())
				.ForMember(dce => dce.DocsAgreements, opt => opt.Ignore())
				.ForMember(dce => dce.DocsBills, opt => opt.Ignore())
				.ForMember(dce => dce.DocsConclusionsObjects, opt => opt.Ignore())
				.ForMember(dce => dce.DocsWithGoods, opt => opt.Ignore());
			CreateMap<DocsConclusionsExaminationViewModel, DocsWithGoods>()
				.ForMember(dce => dce.Gu, opt => opt.MapFrom(s => s))
				.ForMember(dce => dce.DocsActs, opt => opt.Ignore())
				.ForMember(dce => dce.DocsConclusionsExamination, opt => opt.Ignore())
				.ForMember(dce => dce.DocsConclusionsExport, opt => opt.Ignore())
				.ForMember(dce => dce.DocsConclusionsImport, opt => opt.Ignore())
				.ForMember(dce => dce.DocsGoods, opt => opt.MapFrom(s => s.DocsGoods));
			CreateMap<DocsConclusionsExaminationViewModel, DocsConclusionsExamination>()
				.ForMember(dce => dce.Gu, opt => opt.MapFrom(s => s))
				.ForMember(dce => dce.InvoiceTypeGu, opt => opt.Ignore())
				.ForMember(dce => dce.TargetOrSourceGu, opt => opt.Ignore())
				.ForMember(dce => dce.TransportTypeGu, opt => opt.Ignore());

			CreateMap<DocsExaminationTaskViewModel, DocsExaminationTasks>()
				.ForMember(db => db.DateSampling, vm => vm.MapFrom(s => DateTime.ParseExact(s.DateSampling, DocsExaminationTaskViewModel.DateFormat, CultureInfo.InvariantCulture)))
				.ForMember(db => db.DateReceipt, vm => vm.MapFrom(s => DateTime.ParseExact(s.DateReceipt, DocsExaminationTaskViewModel.DateFormat, CultureInfo.InvariantCulture)))
				//.ForMember(db => db.DocsExaminationTasksExaminations, vm => vm.MapFrom<IList<DocsExaminationTasksExaminationsViewModel>>(s => s.TaskExaminations))
				//.ForMember(db => db.OriginCountryId, vm => vm.MapFrom(s => s.OriginCountry.Guid))
				//.ForMember(db => db.SamplingProductionId, vm => vm.MapFrom(s => s.SamplingProduction.Guid))
				;

			CreateMap<DocsExaminationTasksExaminationsViewModel, DocsExaminationTasksExaminations>();

			CreateMap<DocsExaminationTasksExaminations, DocsExaminationTasksExaminationsViewModel>();
		}
	}
}
