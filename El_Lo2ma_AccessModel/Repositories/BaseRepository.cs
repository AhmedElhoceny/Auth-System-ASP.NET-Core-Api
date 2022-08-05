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
    public class BaseRepository<EntityType> : IBaseRepository<EntityType> where EntityType : class
    {
        private readonly Lo2maContext _DbCon;
        internal DbSet<EntityType> _dbSet;

        public BaseRepository(Lo2maContext DbCon)
        {
            _DbCon = DbCon;
            this._dbSet = DbCon.Set<EntityType>();
        }
        public async Task<EntityType> AddAsync(EntityType entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<EntityType>> AddRangeAsync(IEnumerable<EntityType> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<EntityType, bool>> filter = null)
        {
            return await _dbSet.AnyAsync(filter);
        }

        public void Attach(EntityType entity)
        {
            _dbSet.Attach(entity);
        }

        public Task<int> Count(Expression<Func<EntityType, bool>> filter = null)
        {
            return _dbSet.CountAsync(filter);
        }

        public async Task<bool> ExistAsync(Expression<Func<EntityType, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<EntityType> Query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                Query = Query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeProperty);
                }
            }
            var result = await Query.FirstOrDefaultAsync() is not null;
            return result;
        }

        public EntityType FindItem(Expression<Func<EntityType, bool>> filter = null, string? IncludeProperties = null)
        {
            IQueryable<EntityType> Query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                Query = Query.Where(filter);
            }
            if (!string.IsNullOrEmpty(IncludeProperties))
            {
                foreach (var includeProperty in IncludeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeProperty);
                }
            }
            return Query.FirstOrDefault();
        }

        public async Task<EntityType> FindItemAsync(Expression<Func<EntityType, bool>> filter = null, string? IncludeProperties = null) 
        {
            IQueryable<EntityType> Query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                Query = Query.Where(filter);
            }
            if (!string.IsNullOrEmpty(IncludeProperties))
            {
                foreach (var includeProperty in IncludeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeProperty);
                }
            }
            return await Query.FirstOrDefaultAsync();
        }

        public IEnumerable<ViewType> GetAll<ViewType>(Expression<Func<EntityType, bool>> filter = null, Expression<Func<EntityType, ViewType>> Select = null, string? IncludeProperties = null, int? skip = null, int? take = null) where ViewType : class
        {
            IQueryable<EntityType> Query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                Query = Query.Where(filter);
            }
            if (!string.IsNullOrEmpty(IncludeProperties))
            {
                foreach (var includeProperty in IncludeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeProperty);
                }
            }
            if (skip.HasValue)
            {
                Query = Query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                Query = Query.Take(take.Value);
            }
            if (Select != null)
            {
                Query = (IQueryable<EntityType>)Query.Select(Select).ToList();
            }
            return (IEnumerable<ViewType>)Query.ToList();
        }

        public async Task<IEnumerable<EntityType>> GetAllAsync<ViewType>(Expression<Func<EntityType, bool>> filter = null, Expression<Func<EntityType, ViewType>> Select = null, string? IncludeProperties = null, int? skip = null, int? take = null) where ViewType : class
        {
            IQueryable<EntityType> Query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                Query = Query.Where(filter);
            }
            if (!string.IsNullOrEmpty(IncludeProperties))
            {
                foreach (var includeProperty in IncludeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeProperty);
                }
            }
            if (skip.HasValue)
            {
                Query = Query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                Query = Query.Take(take.Value);
            }
            if (Select != null)
            {
                Query = (IQueryable<EntityType>)await Query.Select(Select).ToListAsync();
            }
            return await Query.ToListAsync();
        }

        public EntityType GetFirstOrDefault(Expression<Func<EntityType, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<EntityType> Query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                Query = Query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeProperty);
                }
            }
            return Query.FirstOrDefault();
        }

        public async Task<EntityType> GetFirstOrDefaultAsync(Expression<Func<EntityType, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<EntityType> Query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                Query = Query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeProperty);
                }
            }
            return await Query.FirstOrDefaultAsync();
        }

        public async Task<EntityType> Remove(EntityType entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }

        public async void RemoveRange(IEnumerable<EntityType> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public EntityType Update(EntityType entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public void UpdateRange(IEnumerable<EntityType> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
