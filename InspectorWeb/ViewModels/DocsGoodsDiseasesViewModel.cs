using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace InspectorWeb.ViewModels
{
	[DisplayName("Заболевания продукции")]
	public class DocsGoodsDiseasesViewModel
	{
		//[DisplayName("Номер")] public string Number { get; set; }

		[JsonProperty(PropertyName = "guid")] public Guid Guid { get; set; }
		[JsonProperty(PropertyName = "diaseaseGuid")] public Guid DiaseaseGuid { get; set; }
		[JsonProperty(PropertyName = "count")] public decimal? Count { get; set; }
		[JsonProperty(PropertyName = "countGuid")] public Guid? CountGuid { get; set; }
		[JsonProperty(PropertyName = "diaseaseStateGuid")] public Guid? DiaseaseStateGuid { get; set; }
	}
}