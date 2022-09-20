using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InspectorWeb.ViewModels
{
	public class SettingsViewModel
	{
		[DisplayName("Руководитель")]
		[Required(ErrorMessage = "Требуется непустое имя")]
		public string LaboratoryDirector { get; set; }

		[DisplayName("Должность руководителя")]
		[Required(ErrorMessage = "Требуется непустая должность")]
		public string LaboratoryDirectorTitle { get; set; }

		public SettingsViewModel()
		{
		}
	}
}
