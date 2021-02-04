using Microsoft.EntityFrameworkCore;
using MySchool.Infra.Data.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WpfChallenge.Domain.Entities.Base;
using WpfChallenge.Domain.Interfaces.Base;

namespace WpfChallenge.Data.Infra.Repositories.Base
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
       where TEntity : EntityBase
       where TId : struct
    {
        private readonly WpfChallengeContext _wpfChallengeContext;

        public BaseRepository(WpfChallengeContext wpfChallengeContext)
        {
            _wpfChallengeContext = wpfChallengeContext;
        }

        public IQueryable<TEntity> ListBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return List(includeProperties).Where(where);
        }

        public IQueryable<TEntity> ListAndOrderedBy<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ascendente ? ListBy(where, includeProperties).OrderBy(ordem) : ListBy(where, includeProperties).OrderByDescending(ordem);
        }


        public TEntity GetBy(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return List(includeProperties).FirstOrDefault(where);
        }

        public TEntity GetById(TId id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return List(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _wpfChallengeContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> ListAndPaginationBy(Expression<Func<TEntity, bool>> where, int index, int pageSize = 10)
        {
            return List().Where(where).Skip(index).Take(pageSize);
        }

        public IQueryable<TEntity> List(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _wpfChallengeContext.Set<TEntity>();

            if (includeProperties.Any())
            {
                return Include(_wpfChallengeContext.Set<TEntity>(), includeProperties);
            }
            return query;
        }

        public IQueryable<TEntity> ListOrderedBy<TKey>(Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ascendente ? List(includeProperties).OrderBy(ordem) : List(includeProperties).OrderByDescending(ordem);
        }

        public bool Exist(Func<TEntity, bool> where)
        {
            return _wpfChallengeContext.Set<TEntity>().Any(where);
        }

        public TEntity Add(TEntity entity)
        {
            var _entity = _wpfChallengeContext.Add<TEntity>(entity);
            return _entity.Entity;
        }

        public TEntity Edit(TEntity entity)
        {
            _wpfChallengeContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Remove(TEntity entity)
        {
            _wpfChallengeContext.Set<TEntity>().Remove(entity);
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            _wpfChallengeContext.Set<TEntity>().RemoveRange(entities);
        }

        /// <summary>
        /// Adds a collection of entities for entity framework context
        /// </summary>
        /// <param name="entities">List of entities that should be persisted</param>
        /// <returns></returns>
        public void AddByList(IEnumerable<TEntity> entities)
        {
            _wpfChallengeContext.AddRange(entities);
        }

        /// <summary>
        /// Include populating the object passed by parameter
        /// </summary>
        /// <param name="query">Enter the object of type IQueryable</param>
        /// <param name="includeProperties">Enter the array of expressions that you want to include</param>
        /// <returns></returns>
        private IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }

    }
}
