using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> overrideGetList();

        Task<IEnumerable<TType>> GetSpecificSelectAsync<TType>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, TType>> select,
            bool ignoreQueryFilters = false,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
            ) where TType : class;

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Expression<Func<T, IQueryable<T>>> select = null,
         Expression<Func<T, T>> selector = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> includeFilter = null,
         string includeProperties = null, bool ignoreQueryFilters = false,
         int? skip = null,
         int? take = null);

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
            int? take = null);


        Task<bool> ExistAsync(int id);
        Task<bool> ExistAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null, bool ignoreQueryFilters = false);
        Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null, bool ignoreQueryFilters = false,
              Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null
        );
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null, bool ignoreQueryFilters = false,
              Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null
        );
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> Remove(T entity);
        //Task<bool> RemoveAsync(int id);

        T Update(T entity);
        void Attach(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null, bool ignoreQueryFilters = false);
        int Count(Expression<Func<T, bool>> filter = null, bool ignoreQueryFilters = false);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null, bool ignoreQueryFilters = false);
        void RemoveRange(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
    }
}
