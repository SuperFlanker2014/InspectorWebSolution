using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using InspectorWeb.ModelsDB;
using InspectorWeb.ViewModels;

namespace InspectorWeb.Classes
{
	public class DirectoriesList
    {
		public static readonly List<Type> DirectoriesTypes = new List<Type>
		{
			typeof(DirBanks),
			typeof(DirClientTypes),
			typeof(DirCountries),
			typeof(DirDiaseasesStates),
			typeof(DirDiseases),
			typeof(DirDiseasesGroups),
			typeof(DirDiseasesCounts),
			typeof(DirExaminations),
			typeof(DirGoods),
			typeof(DirGoodsExams),
			typeof(DirGoodsGroups),
			typeof(DirGoodsGroupsCategories),
			typeof(DirInvoiceTypes),
			typeof(DirMarkTypes),
			typeof(DirObjectsCategories),
			typeof(DirPlacesUnits),
			typeof(DirQualityTypes),
			typeof(DirRegionsDistricts),
			typeof(DirSamplesActions),
			typeof(DirServices),
			typeof(DirServicesBillsPatterns),
			typeof(DirServicesGroups),
			typeof(DirServicesPatterns),
			typeof(DirServicesSumFactors),
			typeof(DirServicesUnits),
			typeof(DirTextInspections),
			typeof(DirTextObjectTargetType),
			typeof(DirTextSamplesSourceTypes),
			typeof(DirTextVerdictPatterns),
			typeof(DirTextWoodCompositions),
			typeof(DirTransportTypes),
			typeof(DirUnits),
			typeof(DirUnitsGroups),
			typeof(DirUnitsGroupsDiseases),
			typeof(DirWeightUnits),
			typeof(DirSamplesExaminations),
			typeof(DirExaminationMethods),
			typeof(DirUsers),
			typeof(DirLaboratories)
		};

		private static List<DirectoryItem> directories;

		public static List<DirectoryItem> Directories
		{
			get
			{
				if (directories == null)
				{
					var list = new List<DirectoryItem>();

					foreach (var type in DirectoriesTypes)
					{
						list.Add(new DirectoryItem(
							type.Name, 
							type
							.GetCustomAttribute<ModelMetadataTypeAttribute>()?.MetadataType
							.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName));
					}

					directories = list.OrderBy(directoryItem => directoryItem.Title).ToList();
				}

				return directories;
			}
		}		
	}
}
