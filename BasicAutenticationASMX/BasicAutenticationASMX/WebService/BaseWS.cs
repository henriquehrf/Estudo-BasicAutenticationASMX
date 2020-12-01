using System;
using System.Web;
using Unity;

namespace BasicAutenticationASMX
{
	public abstract class BaseWS<T> : System.Web.Services.WebService where T : class
	{

		public BaseWS()
		{
			InjectDependencies();
		}

		protected virtual void InjectDependencies()
		{
			HttpContext context = HttpContext.Current;
			if(context?.ApplicationInstance is IContainerAccessor containerAccessor)
			{
				IUnityContainer container = containerAccessor.Container;

				if (container == null)
					throw new InvalidOperationException("Container on Global Application Class is Null. Cannot perform BuildUp.");

				container.BuildUp(this as T);
			}
		}
	}
}