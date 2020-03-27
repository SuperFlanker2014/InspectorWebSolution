using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace InspectorWeb.ViewModels
{
	[DisplayName("Продукция")]
	public class DocsExaminationTasksExaminationsViewModel
	{
		[JsonProperty(PropertyName = "guid")] public Guid Guid { get; set; }
		[JsonProperty(PropertyName = "taskId")] public Guid TaskId { get; set; }
		[JsonProperty(PropertyName = "examinationId")] public Guid ExaminationId { get; set; }
		[JsonProperty(PropertyName = "methodId")] public Guid MethodId { get; set; }
		[JsonProperty(PropertyName = "examinationResult")] public string ExaminationResult { get; set; }
		[JsonProperty(PropertyName = "endDate")] public DateTime? EndDate { get; set; }
		[JsonProperty(PropertyName = "userId")] public Guid UserId { get; set; }
		[JsonProperty(PropertyName = "comments")] public string Comments { get; set; }
	}
}