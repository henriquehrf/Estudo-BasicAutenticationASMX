using BasicAutenticationASMX.Core.DTOs;

namespace BasicAutenticationASMX.Dao.Interface
{
	public interface ICredentialDAO
	{
		void Insert(CredentialVO credentialVO);
		void Update(CredentialVO credentialVO);
		CredentialVO GetByToken(string token);
	}
}
