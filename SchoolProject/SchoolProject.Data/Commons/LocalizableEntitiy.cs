using System.Globalization;

namespace SchoolProject.Data.Commons
{
	public class LocalizableEntitiy
	{

		public string GetLocalizer(string textAr, string textEn)
		{
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
			{

				return textAr;
			}
			else
			{

				return textEn;
			}
		}
	}
}
