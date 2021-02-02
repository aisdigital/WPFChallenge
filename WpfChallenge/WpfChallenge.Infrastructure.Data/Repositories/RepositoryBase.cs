using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Domain.Interfaces.Repositories;
using WpfChallenge.Infrastructure.Data.Contexto;

namespace WpfChallenge.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected WpfChallengeContext Db = new WpfChallengeContext();

        public void Add(TEntity obj)
		{
			try
			{
                Db.Set<TEntity>().Add(obj);
                Db.SaveChanges();
            }
			catch (Exception ex)
			{
				throw ex;
			}
            
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
			try
			{
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();
            }
			catch (Exception ex)
			{
				throw ex;
			}
            
        }

        public void Remove(TEntity obj)
        {
			try
			{
                Db.Set<TEntity>().Remove(obj);
                Db.SaveChanges();
            }
			catch (Exception ex)
			{
				throw ex;
			}
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
