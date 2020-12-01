using BasicAutenticationASMX.Core.Dao;
using BasicAutenticationASMX.Core.DTOs;
using BasicAutenticationASMX.Dao.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BasicAutenticationASMX.Dao
{
	public class CredentialDAO : BaseDAO<CredentialVO>, ICredentialDAO
	{

		public static List<CredentialVO> _fakeList;

		public CredentialDAO()
		{
			if (_fakeList == null)
				_fakeList = new List<CredentialVO>();
		}

		public CredentialVO GetByToken(string token)
		{
			return _fakeList.SingleOrDefault(t => t.Token == token);
		}

		public void Insert(CredentialVO credentialVO)
		{
			Insert(_fakeList, credentialVO);
		}

		public void Update(CredentialVO credentialVO)
		{
			Update(_fakeList, credentialVO);
		}
	}
}