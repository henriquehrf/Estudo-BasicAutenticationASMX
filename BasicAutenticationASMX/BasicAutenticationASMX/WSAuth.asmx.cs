using BasicAutenticationASMX.Core;
using BasicAutenticationASMX.Core.Dao;
using BasicAutenticationASMX.Core.DTOs;
using BasicAutenticationASMX.Dao;
using BasicAutenticationASMX.Service;
using BasicAutenticationASMX.Service.Interface;
using BasicAutenticationASMX.VO;
using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
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
		public Authentication _authHeader;

		[Dependency]
		public IAuthService AuthService { get; set; }
		[Dependency]
		public ICredentialService CredentialService { get; set; }

		public WSAuth() : base()
		{

		}
		[WebMethod]
		[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public CredentialVO Authenticate(string user, string password)
		{
			if (AuthService.Autenticate(user, password))
			{
				var credential = CredentialService.Generate(Context.Request.UserHostAddress);
				return credential;
			}

			return default;
		}

		[WebMethod]
		[SoapHeader("_authHeader")]
		[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public string AddXpto(StudentVO studentVO)
		{
			if (string.IsNullOrEmpty(_authHeader?.Token))
				throw new UnauthorizedAccessException();

			var credentialDAO = new CredentialDAO();
			var credentialVO = credentialDAO.GetByToken(_authHeader?.Token);
			if (credentialVO?.Expired >= DateTime.UtcNow &&
				credentialVO.IpHost == Context.Request.UserHostAddress)
				return Guid.NewGuid().ToString();

			return "Failed!";

		}

		[WebMethod]
		[SoapHeader("_authHeader")]
		[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public string AddXptoList(List<StudentVO> studentVO)
		{
			if (string.IsNullOrEmpty(_authHeader?.Token))
				throw new UnauthorizedAccessException();

			var credentialDAO = new CredentialDAO();
			var credentialVO = credentialDAO.GetByToken(_authHeader?.Token);
			if (credentialVO?.Expired >= DateTime.UtcNow &&
				credentialVO.IpHost == Context.Request.UserHostAddress)
				return Guid.NewGuid().ToString();

			return "Failed!";

		}

	}

	public class Authentication : SoapHeader
	{
		public string Token { get; set; }
	}
}
