using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace InspectorWeb.ViewModels
{
	[DisplayName("Шифры")]
	public class DocsExaminationTasksCiphersViewModel
	{
		[JsonProperty(PropertyName = "guid")] public Guid Guid { get; set; }
		[JsonProperty(PropertyName = "taskId")] public Guid TaskId { get; set; }
		[JsonProperty(PropertyName = "cipher")] public string Cipher { get; set; }
		[JsonProperty(PropertyName = "safePackageNumber")] public string SafePackageNumber { get; set; }
		[JsonProperty(PropertyName = "sampleTitle")] public string SampleTitle { get; set; }
		[JsonProperty(PropertyName = "weightUnitId")] public Guid? WeightUnitId { get; set; }
		[JsonProperty(PropertyName = "count")] public decimal? Count { get; set; }
		[JsonProperty(PropertyName = "comments")] public string Comments { get; set; }
	}
}