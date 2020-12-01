using BasicAutenticationASMX.Core;
using BasicAutenticationASMX.Core.Dao;
using BasicAutenticationASMX.Dao;
using BasicAutenticationASMX.Dao.Interface;
using BasicAutenticationASMX.Service;
using BasicAutenticationASMX.Service.Interface;
using Unity;

namespace BasicAutenticationASMX.App_Start
{
	public static class DependencyInjection
	{

		public static void AddDependency(this IUnityContainer container)
		{
			container.RegisterType<IAuthService, AuthService>();
			container.RegisterType<IAuthDAO, AuthDAO>();
			container.RegisterType<ICredentialService, CredentialService>();
			container.RegisterType<ICredentialDAO, CredentialDAO>();

		}
	}
}