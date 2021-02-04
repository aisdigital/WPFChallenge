using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WpfChallenge.Domain.Interfaces.Base
{
    public interface IBaseRepository<TEntity, TId> where TEntity : class
     where TId : struct
    {
        IQueryable<TEntity> ListBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> ListAndOrderedBy<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetBy(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties);

        bool Exist(Func<TEntity, bool> where);

        IQueryable<TEntity> List(params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> ListAndPaginationBy(Expression<Func<TEntity, bool>> where, int indice, int tamanhoPagina = 10);

        IQueryable<TEntity> ListOrderedBy<TKey>(Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetById(TId id, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Add(TEntity entity);

        TEntity Edit(TEntity entity);

        void Remove(TEntity entity);

        void Remove(IEnumerable<TEntity> entities);

        void AddByList(IEnumerable<TEntity> entities);
    }
}
