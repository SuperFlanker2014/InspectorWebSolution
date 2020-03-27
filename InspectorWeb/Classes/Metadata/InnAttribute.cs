using System;
using System.ComponentModel.DataAnnotations;

namespace InspectorWeb.ModelsDB
{
	public class InnAttribute : ValidationAttribute
	{
		public InnAttribute()
		{

		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var innString = value?.ToString();

			if (string.IsNullOrEmpty(innString) || (innString.Length != 10 && innString.Length != 12))
			{
				return new ValidationResult(ErrorMessage);
			}

			long inn;

			if (!Int64.TryParse(innString, out inn))
			{
				return new ValidationResult(ErrorMessage);
			}

			if (innString.Length == 10)
			{
				int dgt10 = 0;

				try
				{
					dgt10 = (((2 * Int32.Parse(innString.Substring(0, 1))
						+ 4 * Int32.Parse(innString.Substring(1, 1))
						+ 10 * Int32.Parse(innString.Substring(2, 1))
						+ 3 * Int32.Parse(innString.Substring(3, 1))
						+ 5 * Int32.Parse(innString.Substring(4, 1))
						+ 9 * Int32.Parse(innString.Substring(5, 1))
						+ 4 * Int32.Parse(innString.Substring(6, 1))
						+ 6 * Int32.Parse(innString.Substring(7, 1))
						+ 8 * Int32.Parse(innString.Substring(8, 1))) % 11) % 10);
				}
				catch
				{
					return new ValidationResult(ErrorMessage);
				}

				if (Int32.Parse(innString.Substring(9, 1)) != dgt10)
				{
					return new ValidationResult(ErrorMessage);
				}
			}
			else // для физического лица
			{
				int dgt11 = 0, dgt12 = 0;

				try
				{
					dgt11 = (((
						7 * Int32.Parse(innString.Substring(0, 1))
						+ 2 * Int32.Parse(innString.Substring(1, 1))
						+ 4 * Int32.Parse(innString.Substring(2, 1))
						+ 10 * Int32.Parse(innString.Substring(3, 1))
						+ 3 * Int32.Parse(innString.Substring(4, 1))
						+ 5 * Int32.Parse(innString.Substring(5, 1))
						+ 9 * Int32.Parse(innString.Substring(6, 1))
						+ 4 * Int32.Parse(innString.Substring(7, 1))
						+ 6 * Int32.Parse(innString.Substring(8, 1))
						+ 8 * Int32.Parse(innString.Substring(9, 1))) % 11) % 10);

					dgt12 = (((
						3 * Int32.Parse(innString.Substring(0, 1))
						+ 7 * Int32.Parse(innString.Substring(1, 1))
						+ 2 * Int32.Parse(innString.Substring(2, 1))
						+ 4 * Int32.Parse(innString.Substring(3, 1))
						+ 10 * Int32.Parse(innString.Substring(4, 1))
						+ 3 * Int32.Parse(innString.Substring(5, 1))
						+ 5 * Int32.Parse(innString.Substring(6, 1))
						+ 9 * Int32.Parse(innString.Substring(7, 1))
						+ 4 * Int32.Parse(innString.Substring(8, 1))
						+ 6 * Int32.Parse(innString.Substring(9, 1))
						+ 8 * Int32.Parse(innString.Substring(10, 1))) % 11) % 10);
				}
				catch
				{
					return new ValidationResult(ErrorMessage);
				}

				if (Int32.Parse(innString.Substring(10, 1)) != dgt11 || Int32.Parse(innString.Substring(11, 1)) != dgt12)
				{
					return new ValidationResult(ErrorMessage);
				}
			}

			return ValidationResult.Success;
		}
	}
}