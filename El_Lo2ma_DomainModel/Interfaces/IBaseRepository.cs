using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Interfaces
{
    public interface IBaseRepository<EntityType> where EntityType : class
    {
        Task<IEnumerable<EntityType>> GetAllAsync<ViewType>(
            Expression<Func<EntityType, bool>> filter = null,
            Expression<Func<EntityType, ViewType>> Select = null,
            string? IncludeProperties = null,
            int? skip = null,
            int? take = null) where ViewType : class;
        IEnumerable<ViewType> GetAll<ViewType>(
            Expression<Func<EntityType, bool>> filter = null,
            Expression<Func<EntityType, ViewType>> Select = null,
            string? IncludeProperties = null,
            int? skip = null,
            int? take = null) where ViewType : class;
        Task<EntityType> FindItemAsync(Expression<Func<EntityType, bool>> filter = null,
            string? IncludeProperties = null);
        EntityType FindItem(Expression<Func<EntityType, bool>> filter = null,
            string? IncludeProperties = null);
        Task<bool> ExistAsync(Expression<Func<EntityType, bool>> filter = null, string includeProperties = null);
        Task<EntityType> GetFirstOrDefaultAsync(
            Expression<Func<EntityType, bool>> filter = null,
            string includeProperties = null
        );
        EntityType GetFirstOrDefault(
            Expression<Func<EntityType, bool>> filter = null,
            string includeProperties = null
        );
        Task<EntityType> AddAsync(EntityType entity);
        Task<IEnumerable<EntityType>> AddRangeAsync(IEnumerable<EntityType> entities);
        Task<EntityType> Remove(EntityType entity);
        //Task<bool> RemoveAsync(int id);

        EntityType Update(EntityType entity);
        void Attach(EntityType entity);
        Task<int> Count(Expression<Func<EntityType, bool>> filter = null);
        Task<bool> AnyAsync(Expression<Func<EntityType, bool>> filter = null);
        void RemoveRange(IEnumerable<EntityType> entities);
        void UpdateRange(IEnumerable<EntityType> entities);
    }
}
