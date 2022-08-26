using El_Lo2ma_AccessModel.Contexts;
using El_Lo2ma_DomainModel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_AccessModel.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        internal DbSet<T> dbSet;

        public BaseRepository(Lo2maContext DbCon)
        {
            this.dbSet = DbCon.Set<T>();
        }
        //GetByIdAsync method use tracking to get object (to update ,insert)
        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> overrideGetList()
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<TType>> GetSpecificSelectAsync<TType>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, TType>> select,
            bool ignoreQueryFilters = false,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null

            ) where TType : class
        {

            IQueryable<T> query = dbSet.AsNoTracking();
            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }
            if (includeProperties != null)
            {
                query.AsSplitQuery();
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty).IgnoreQueryFilters();
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
                query = orderBy(query);

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            var x = await query.Select(select).ToListAsync();
            return x;
        }
        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, IQueryable<T>>> select = null,
            Expression<Func<T, T>> selector = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, bool>> includeFilter = null,
            string includeProperties = null
            , bool ignoreQueryFilters = false,
            int? skip = null,
            int? take = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }
            //example var customers = context.Customers.IncludeFilter(x => x.Invoices.Where(y => !y.IsSoftDeleted))
            if (includeFilter is not null)
            {
                query = query.Include(includeFilter);
            }

            if (select != null)
            {
                query = (IQueryable<T>)query.Select(select);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty)/*.IgnoreQueryFilters()*/;
                }
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            if (orderBy != null)
            {

                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, IQueryable<T>>> select = null,
            Expression<Func<T, T>> selector = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, bool>> includeFilter = null,
            string includeProperties = null
            , bool ignoreQueryFilters = false,
            int? skip = null,
            int? take = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }
            //example var customers = context.Customers.IncludeFilter(x => x.Invoices.Where(y => !y.IsSoftDeleted))
            if (includeFilter is not null)
            {
                query = query.Include(includeFilter);
            }

            if (select != null)
            {
                query = (IQueryable<T>)query.Select(select);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty)/*.IgnoreQueryFilters()*/;
                }
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            if (orderBy != null)
            {

                return orderBy(query).ToList();
            }

            return query.ToList();
        }





        public async Task<bool> ExistAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            return entity is not null;
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null, bool ignoreQueryFilters = false
          )
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            var result = await query.FirstOrDefaultAsync() is not null;
            return result;
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null,
            string includeProperties = null, bool ignoreQueryFilters = false
              , Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null
            )
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {

                return await orderBy(query).FirstOrDefaultAsync();
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return entities;
        }
        public async Task<T> Remove(T entity)
        {

            dbSet.Remove(entity);
            return entity;
            //return await _context.SaveChangesAsync() > 0;

        }

        //public async Task<bool> RemoveAsync(int id)
        //{
        //    T removedEntity = await dbSet.FindAsync(id);
        //    return await RemoveAsync(removedEntity);

        //}

        public T Update(T entity)
        {
            dbSet.Update(entity);
            return entity;
        }


        public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }
        public int Count(Expression<Func<T, bool>> filter = null, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.AnyAsync();
        }
        public void Attach(T entity)
        {

            dbSet.Attach(entity);
        }

        public void RemoveRange(IEnumerable<T> entities) =>
                dbSet.RemoveRange(entities);

        public void UpdateRange(IEnumerable<T> entities) =>
            dbSet.UpdateRange(entities);

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null, bool ignoreQueryFilters = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {

                return orderBy(query).FirstOrDefault();
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            return entities;
        }
    }
}
