/// <summary>
/// Ioc Unity configurations
/// </summary>

namespace Ado.Host
{
    #region import namespaces

    using System.Web.Mvc;
    using Unity;
    using Unity.Mvc5;
    using Unity.Injection;
    using Ado.DataAccess.Infrastructure.Database;
    using Ado.DataAccess.Repositories;
    using Ado.DataAccess.Repositories.Interfaces;
    using System.Configuration;
    
    #endregion

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // connection string to pass dbfactory
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ToString();

            // register db factory with connection string
            container.RegisterType<IDbFactory, DbFactory>(new InjectionConstructor(connectionString));

            // register all your repositories
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}