using Newtonsoft.Json.Converters;

namespace InspectorWeb.Classes
{
	public class CustomDateTimeConverter : IsoDateTimeConverter
	{
		public CustomDateTimeConverter()
		{
			base.DateTimeFormat = "yyyy.MM.dd";
		}
	}
}