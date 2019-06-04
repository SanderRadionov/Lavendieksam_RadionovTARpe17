using System.Web;
using System.Web.Mvc;

namespace Lavendieksam_RadionovTARpe17
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
