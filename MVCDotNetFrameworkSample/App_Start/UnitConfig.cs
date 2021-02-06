using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using DapperGenericDataManager;
using MVCDotNetFrameworkSample.Services;

namespace MVCDotNetFrameworkSample.App_Start
{
    public static class UnitConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IDbConnectionFactory, MySQLConnection>("Main");


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
}