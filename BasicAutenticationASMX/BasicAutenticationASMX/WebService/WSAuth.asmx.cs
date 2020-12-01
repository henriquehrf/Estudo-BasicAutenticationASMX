using BasicAutenticationASMX.Core.DTOs;
using BasicAutenticationASMX.Service.Interface;
using System;
using System.Web.Script.Services;
using System.Web.Services;
using Unity.Attributes;

namespace BasicAutenticationASMX
{
	/// <summary>
	/// Summary description for WSAuth
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class WSAuth : BaseWS<WSAuth>
	{
		[Dependency]
		public IAuthService AuthService { get; set; }
		[Dependency]
		public ICredentialService CredentialService { get; set; }

		public WSAuth() : base()
		{ }

		[WebMethod]
		[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public CredentialVO Authenticate(string user, string password)
		{
			if (AuthService.Autenticate(user, password))
			{
				var credential = CredentialService.Generate(Context.Request.UserHostAddress);
				return credential;
			}

			throw new UnauthorizedAccessException();
		}
	}
}
