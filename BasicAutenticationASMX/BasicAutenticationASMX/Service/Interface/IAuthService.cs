namespace BasicAutenticationASMX.Service.Interface
{
	public interface IAuthService
	{
		bool Autenticate(string user, string password);
	}
}
