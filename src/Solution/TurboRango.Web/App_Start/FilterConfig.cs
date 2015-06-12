using System.Web;
using System.Web.Mvc;
using TurboRango.Web.App_Start;

namespace TurboRango.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
