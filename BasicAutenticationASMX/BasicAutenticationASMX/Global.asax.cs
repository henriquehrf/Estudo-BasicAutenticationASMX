using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using System;
using System.Web;
using System.Web.Routing;
using BasicAutenticationASMX.App_Start;
using Unity;

namespace BasicAutenticationASMX
{
	public class Global : HttpApplication, IContainerAccessor
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        IUnityContainer IContainerAccessor.Container
        {
            get
            {
                return Container;
            }
        }

        protected void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			IUnityContainer container = new UnityContainer();
			DependencyInjection.AddDependency(container);
			Container = container;
		}
	}
}