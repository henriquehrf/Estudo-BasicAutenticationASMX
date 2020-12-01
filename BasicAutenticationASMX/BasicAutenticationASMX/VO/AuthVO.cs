using BasicAutenticationASMX.Core.VO;

namespace BasicAutenticationASMX.Core
{
	public sealed class AuthVO: BaseVO
	{
		public string User { get; set; }
		public string Password { get; set; }
	}
}