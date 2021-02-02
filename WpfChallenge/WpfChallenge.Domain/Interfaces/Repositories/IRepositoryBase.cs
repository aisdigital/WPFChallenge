using System.Collections.Generic;

namespace WpfChallenge.Domain.Interfaces.Repositories
{
	public interface IRepositoryBase<TEntity> where TEntity : class
	{
		bool Add(TEntity obj);

		TEntity GetById(int id);

		IEnumerable<TEntity> GetAll();

		bool Update(TEntity obj);

		bool Remove(TEntity obj);

		void Dispose();
	}
}