using BasicAutenticationASMX.Core.VO;
using System;
using System.Xml.Serialization;

namespace BasicAutenticationASMX.Core.DTOs
{
	public sealed class CredentialVO: BaseVO
	{
		public string Token { get; set; }
		public DateTime Created { get; set; }
		public DateTime Expired { get; set; }
		[XmlIgnore]
		public string IpHost { get; set; }
		[XmlIgnore]
		public bool Active { get; set; }

	}
}