using BasicAutenticationASMX.Core.VO;
using System;
using System.Collections.Generic;

namespace BasicAutenticationASMX.Core.Dao
{
	public abstract class BaseDAO<T> where T : class
	{
		public void Insert(IList<T> fake, T t) => fake.Add(t);
		public void Delete(IList<T> fake, T t) => fake.Remove(t);
		public void Update(IList<T> fake, T t)
		{
			var baseVO = t as BaseVO;

			if (baseVO == null)
				throw new InvalidOperationException("ID inválido");

			int indice = 0;
			foreach (var item in fake)
			{
				if (item is BaseVO r && r.ID == baseVO.ID)
					break;

				indice++;
			}

			fake[indice] = t;
		}
		public T GetByID(IList<T> fake, int id)
		{
			int indice = 0;
			foreach (var item in fake)
			{
				if (item is BaseVO r && r.ID == id)
					break;

				indice++;
			}

			return fake[indice];
		}
	}
}