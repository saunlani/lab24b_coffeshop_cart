using System.Web;
using System.Web.Mvc;

namespace lab24b_coffeeshop_cart
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
