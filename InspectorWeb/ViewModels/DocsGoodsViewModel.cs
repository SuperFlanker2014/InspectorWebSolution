using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace InspectorWeb.ViewModels
{
	[DisplayName("Продукция")]
	public class DocsGoodsViewModel
	{
		//[DisplayName("Номер")] public string Number { get; set; }

		[JsonProperty(PropertyName = "guid")] public Guid Guid { get; set; }
		[JsonProperty(PropertyName = "docGuid")] public Guid DocGuid { get; set; }
		[JsonProperty(PropertyName = "goodGuid")] public Guid GoodGuid { get; set; }
		[JsonProperty(PropertyName = "productionCountryGuid")] public Guid ProductionCountryGuid { get; set; }
		[JsonProperty(PropertyName = "places")] public int? Places { get; set; }
		[JsonProperty(PropertyName = "placesUnitGuid")] public Guid? PlacesUnitGuid { get; set; }
		[JsonProperty(PropertyName = "weight")] public decimal? Weight { get; set; }
		[JsonProperty(PropertyName = "weightUnitGuid")] public Guid? WeightUnitGuid { get; set; }
		[JsonProperty(PropertyName = "samplesCount")] public int? SamplesCount { get; set; }

		[JsonProperty(PropertyName = "diseases")] public DocsGoodsDiseasesViewModel[] Diseases { get; set; }
	}
}