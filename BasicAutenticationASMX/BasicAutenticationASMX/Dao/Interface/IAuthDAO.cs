using BasicAutenticationASMX.Core;

namespace BasicAutenticationASMX.Dao.Interface
{
	public interface IAuthDAO
	{
		AuthVO GetByUser(string user);
	}
}
