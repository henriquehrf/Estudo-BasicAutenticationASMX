using System.Web.Services.Protocols;

namespace BasicAutenticationASMX.VO
{
	public class Authentication : SoapHeader
	{
		public string Token { get; set; }
	}
}