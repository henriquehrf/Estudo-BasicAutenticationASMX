using System;
using System.Web;
using System.Web.Services;
using Unity;

namespace BasicAutenticationASMX
{
	public abstract class BaseWS<T> : WebService where T : class
	{

		public BaseWS()
		{
			InjectDependencies();
		}

        protected virtual void InjectDependencies()
        {
            HttpContext context = HttpContext.Current;

            if (context == null)
                return;

			IContainerAccessor accessor = context.ApplicationInstance as IContainerAccessor;

			if (accessor == null)
				return;

			IUnityContainer container = accessor.Container;

			if (container == null)
				throw new InvalidOperationException("Container on Global Application Class is Null. Cannot perform BuildUp.");

			container.BuildUp(this as T);
		}
    }
}