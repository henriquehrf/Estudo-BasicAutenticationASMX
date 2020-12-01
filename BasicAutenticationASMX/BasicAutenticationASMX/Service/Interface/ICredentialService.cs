using BasicAutenticationASMX.Core.DTOs;

namespace BasicAutenticationASMX.Service.Interface
{
	public interface ICredentialService
	{
		CredentialVO Generate(string ipHost);

	}
}
