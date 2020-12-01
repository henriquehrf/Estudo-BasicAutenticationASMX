using BasicAutenticationASMX.Dao.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BasicAutenticationASMX.Core.Dao
{
	public class AuthDAO : BaseDAO<AuthVO>, IAuthDAO
	{
		public static List<AuthVO> _fakeList;
		public AuthDAO()
		{
			if (_fakeList == null)
			{
				_fakeList = new List<AuthVO>()
				{
					new AuthVO(){User="Henrique", Password="hh8901232"},
					new AuthVO(){User="Fulano", Password="1234"}
				};
			}
		}

		public AuthVO GetByUser(string user)
		{
			return _fakeList.SingleOrDefault(u => u.User == user);
		}
	}
}