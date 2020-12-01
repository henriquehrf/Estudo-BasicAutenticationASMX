using BasicAutenticationASMX.Core.DTOs;
using BasicAutenticationASMX.Dao.Interface;
using BasicAutenticationASMX.Service.Interface;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BasicAutenticationASMX.Core
{
	public class CredentialService : ICredentialService
	{
		private readonly ICredentialDAO _credentialDAO;

		public CredentialService(ICredentialDAO credentialDAO)
		{
			_credentialDAO = credentialDAO;
		}

		public CredentialVO Generate(string ipHost)
		{
			using (SHA512 sha512 = SHA512.Create())
			{
				StringBuilder builder = new StringBuilder();
				foreach (byte hash in Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()))))
					builder.Append(hash.ToString("x2"));

				var credential = new CredentialVO()
				{
					Created = DateTime.Now,
					Expired = DateTime.Now.AddHours(24),
					IpHost = ipHost,
					Token = builder.ToString(),
					Active = true
				};

				_credentialDAO.Insert(credential);
				return credential;

			}

		}

		public CredentialVO GetByToken(string token)
		{
			return _credentialDAO.GetByToken(token);
		}
	}
}