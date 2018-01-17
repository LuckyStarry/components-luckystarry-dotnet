using LuckyStarry.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStarry.Services
{
    public interface IDbService<TEntity> : IService
        where TEntity : IEntity
    {
        IEnumerable<Data.Objects.IDbColumn> Columns { get; }
        Data.Objects.IDbTable Table { get; }
        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();
    }

    public interface IDbService<TEntity, TPrimary> : IDbService<TEntity>
        where TEntity : IEntity<TPrimary>
    {
        Data.Objects.IDbColumn PrimaryKey { get; }
        TEntity GetById(TPrimary id);
        TPrimary Insert(TEntity model);
        bool LogicalDelete(TPrimary id);
        bool PhysicalDelete(TPrimary id);
        bool Update(TEntity model);

        Task<TEntity> GetByIdAsync(TPrimary id);
        Task<TPrimary> InsertAsync(TEntity model);
        Task<bool> LogicalDeleteAsync(TPrimary id);
        Task<bool> PhysicalDeleteAsync(TPrimary id);
        Task<bool> UpdateAsync(TEntity model);
    }
}
