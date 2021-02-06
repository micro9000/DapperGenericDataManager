using DapperGenericDataManager;
using MVCDotNetFrameworkSample.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MVCDotNetFrameworkSample
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IDbConnectionFactory, MySQLConnection>("Main");
            container.RegisterType<IStudentsData, StudentsData>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}