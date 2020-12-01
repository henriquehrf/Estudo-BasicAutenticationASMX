using BasicAutenticationASMX.Dao.Interface;
using BasicAutenticationASMX.Service.Interface;

namespace BasicAutenticationASMX.Service
{
	public class AuthService : IAuthService
	{
		private IAuthDAO _authDAO;

		public AuthService(IAuthDAO authDAO)
		{
			_authDAO = authDAO;
		}

		public bool Autenticate(string user, string password)
		{
			return _authDAO.GetByUser(user)?.Password == password;
		}
	}
}