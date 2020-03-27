using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;

namespace InspectorWeb.ModelsDB
{
	[ModelMetadataType(typeof(MetaData))]
	public partial class DocsGoodsDiseases
    {
		//[DisplayName("Свидетельства экспертизы")]
		public class MetaData
		{
			public Guid Guid { get; set; }
			public Guid DiaseaseGuid { get; set; }
			public decimal? Count { get; set; }
			public Guid? CountGuid { get; set; }
			public Guid? DiaseaseStateGuid { get; set; }

			public DirDiseasesCounts CountGu { get; set; }
			public DirDiseases DiaseaseGu { get; set; }
			public DirDiaseasesStates DiaseaseStateGu { get; set; }
			public DocsGoods Gu { get; set; }
		}
    }
}