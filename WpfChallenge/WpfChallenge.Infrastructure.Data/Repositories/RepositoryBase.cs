using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WpfChallenge.Domain.Interfaces.Repositories;
using WpfChallenge.Infrastructure.Data.Contexto;

namespace WpfChallenge.Infrastructure.Data.Repositories
{
	public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
	{
		protected WpfChallengeContext Db = new WpfChallengeContext();

		#region Add
		public bool Add(TEntity obj)
		{
			try
			{
				Db.Set<TEntity>().Add(obj);
				Db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region GetById
		public TEntity GetById(int id)
		{
			return Db.Set<TEntity>().Find(id);
		}
		#endregion

		#region GetAll
		public IEnumerable<TEntity> GetAll()
		{
			return Db.Set<TEntity>().ToList();
		}
		#endregion

		#region Update
		public bool Update(TEntity obj)
		{
			try
			{
				Db.Entry(obj).State = EntityState.Modified;
				Db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region Remove
		public bool Remove(TEntity obj)
		{
			try
			{
				Db.Set<TEntity>().Remove(obj);
				Db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		#endregion

	}
}