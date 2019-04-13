/// <summary>
/// Filter configurations
/// </summary>

namespace Ado.Host
{
    #region import namespaces

    using System.Web.Mvc;

    #endregion

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
