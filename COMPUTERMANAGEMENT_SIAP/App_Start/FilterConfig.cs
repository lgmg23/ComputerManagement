using System.Web;
using System.Web.Mvc;

namespace COMPUTERMANAGEMENT_SIAP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
