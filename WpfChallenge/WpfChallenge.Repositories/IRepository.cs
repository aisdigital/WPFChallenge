using System;
using System.Linq;
using System.Linq.Expressions;

namespace WpfChallenge.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Search(Expression<Func<T, bool>> predicate);
        T FindById(int id);
        T Create(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
