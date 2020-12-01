using BasicAutenticationASMX.Core.DTOs;
using BasicAutenticationASMX.Dao.Interface;
using BasicAutenticationASMX.Service.Interface;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BasicAutenticationASMX.Core
{
	public class CredentialService: ICredentialService
	{
		private readonly ICredentialDAO _credencialDAO;

		public CredentialService(ICredentialDAO credencialDAO)
		{
			_credencialDAO = credencialDAO;
		}

		public CredentialVO Generate(string ipHost)
		{
			using (SHA512 sha512 = SHA512.Create())
			{
				var credential = new CredentialVO()
				{
					Created = DateTime.UtcNow,
					Expired = DateTime.UtcNow.AddHours(24),
					Active = true
				};

				StringBuilder builder = new StringBuilder();

				foreach (byte hash in Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()))))
					builder.Append(hash.ToString("x2"));

				credential.Token = builder.ToString();
				credential.IpHost = ipHost;

				_credencialDAO.Insert(credential);
				return credential;

			}

		}

	}
}