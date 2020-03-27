using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspectorWeb.ModelsDB
{
	[ModelMetadataType(typeof(MetaData))]
	public partial class DocsGoods
    {
		[DisplayName("Свидетельства экспертизы")]
		public new class MetaData
		{
			public Guid Guid { get; set; }
			public Guid DocGuid { get; set; }
			public Guid GoodGuid { get; set; }
			public Guid ProductionCountryGuid { get; set; }
			public int? Places { get; set; }
			public Guid? PlacesUnitGuid { get; set; }
			public decimal? Weight { get; set; }
			public Guid? WeightUnitGuid { get; set; }
			public int? SamplesCount { get; set; }

			public DocsWithGoods DocGu { get; set; }
			public DirGoods GoodGu { get; set; }
			public DirPlacesUnits PlacesUnitGu { get; set; }
			public DirCountries ProductionCountryGu { get; set; }
			public DirWeightUnits WeightUnitGu { get; set; }
			public ICollection<DocsGoodsDiseases> DocsGoodsDiseases { get; set; }			
		}		
	}
}