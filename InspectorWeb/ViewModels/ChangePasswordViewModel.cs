using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace InspectorWeb.ViewModels
{
	public class ChangePasswordViewModel
	{
		public ChangePasswordViewModel()
		{

		}

		[DisplayName("Старый пароль")]
		public string PasswordOld { get; set; }
		[DisplayName("Новый пароль")]
		public string PasswordNew1 { get; set; }
		[DisplayName("Повторите новый пароль")]
		public string PasswordNew2 { get; set; }

		public string Message { get; set; }
	}
}