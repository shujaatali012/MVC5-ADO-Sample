﻿/// <summary>
/// Global.ascx implementations
/// </summary>

namespace Ado.Host
{
    #region import namespaces

    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    #endregion

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
