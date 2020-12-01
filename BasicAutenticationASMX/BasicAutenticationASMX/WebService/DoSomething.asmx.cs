using BasicAutenticationASMX.Service.Interface;
using BasicAutenticationASMX.VO;
using System;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using Unity.Attributes;

namespace BasicAutenticationASMX.WebService
{
	/// <summary>
	/// Summary description for DoSomething
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class DoSomething : System.Web.Services.WebService
	{
		public Authentication _authHeader;

		[Dependency]
		public ICredentialService CredentialService { get; set; }

		[WebMethod]
		[SoapHeader("_authHeader")]
		[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public string DoSomethingMethod()
		{
			if (string.IsNullOrEmpty(_authHeader?.Token))
				throw new UnauthorizedAccessException(message: "Required Token!");

			var credentialVO = CredentialService.GetByToken(_authHeader?.Token);
			if (credentialVO?.Expired >= DateTime.Now &&
				credentialVO.IpHost == Context.Request.UserHostAddress)
			{
				//Do Something here and return GUID Code.
				return Guid.NewGuid().ToString();
			}

			throw new UnauthorizedAccessException(message: "Token expired!");
		}
	}
}
