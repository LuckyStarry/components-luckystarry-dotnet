using LuckyStarry.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Services
{
    public interface IDbService<TEntity> : IService
        where TEntity : IEntity
    {
        string[] Columns { get; }
        string DatabaseName { get; }
        string TableName { get; }
        IEnumerable<TEntity> GetAll();
    }

    public interface IDbService<TEntity, TPrimary> : IDbService<TEntity>
        where TEntity : IEntity<TPrimary>
    {
        string PrimaryKey { get; }
        TEntity GetById(TPrimary id);
        TPrimary Insert(TEntity model);
        bool LogicalDelete(TPrimary id);
        bool PhysicalDelete(TPrimary id);
        bool Update(TEntity model);
    }
}
