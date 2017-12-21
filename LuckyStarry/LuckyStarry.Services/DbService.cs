using Dapper;
using LuckyStarry.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStarry.Services
{
    public abstract class DbService<TEntity> : Service, IDbService<TEntity>
       where TEntity : Models.IEntity
    {
        private readonly IDbClient client;
        public DbService(IDbClient client) => this.client = client;

        public virtual string[] Columns { get; } = typeof(TEntity).GetProperties().Select(p => p.Name).ToArray();

        public virtual string TableName { get; } = typeof(TEntity).Name;

        private string GetAllSqlText() => this.client
                .GetCommandFactory()
                .CreateSelectBuilder()
                .Columns(this.Columns)
                .From(this.TableName)
                .Build();

        public virtual IEnumerable<TEntity> GetAll() => this.client.Query<TEntity>(this.GetAllSqlText());
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await this.client.QueryAsync<TEntity>(this.GetAllSqlText());
    }

    public abstract class DbService<TEntity, TPrimary> : DbService<TEntity>, IDbService<TEntity, TPrimary>
       where TEntity : Models.IEntity<TPrimary>
    {
        private readonly IDbClient client;
        public DbService(IDbClient client) : base(client) => this.client = client;

        public virtual string PrimaryKey { get; } = nameof(Models.IEntity<TPrimary>.ID);

        private string GetByIdSqlText(string idKey)
        {
            var factory = this.client.GetCommandFactory();
            return factory
                .CreateSelectBuilder()
                .Columns(this.Columns)
                .From(this.TableName)
                .Where(factory.GetConditionFactory().EqualTo(this.PrimaryKey, idKey))
                .Build();
        }

        public virtual TEntity GetById(TPrimary id) => this.client.QueryFirstOrDefault<TEntity>(this.GetByIdSqlText(nameof(id)), new { id });
        public virtual async Task<TEntity> GetByIdAsync(TPrimary id) => await this.client.QueryFirstOrDefaultAsync<TEntity>(this.GetByIdSqlText(nameof(id)), new { id });

        private string GetInsertSqlText()
        {
            var factory = this.client.GetCommandFactory();
            return factory
                .CreateInsertBuilder()
                .Into(this.TableName)
                .Columns(this.Columns)
                .Values(this.Columns)
                .Build();
        }

        public virtual TPrimary Insert(TEntity model)
        {
            var sqlText = this.GetInsertSqlText();
            return this.client.ExecuteNonQuery(sqlText, model) > 0 ? model.ID : throw new InsertFailedException(sqlText);
        }

        public virtual async Task<TPrimary> InsertAsync(TEntity model)
        {
            var sqlText = this.GetInsertSqlText();
            return await this.client.ExecuteNonQueryAsync(sqlText, model) > 0 ? model.ID : throw new InsertFailedException(sqlText);
        }

        public virtual bool LogicalDelete(TPrimary id)
        {
            return this.Update(new { ID = id }, new { LogicalDelete = 1 }) > 0;
        }

        public virtual async Task<bool> LogicalDeleteAsync(TPrimary id)
        {
            return await this.UpdateAsync(new { ID = id }, new { LogicalDelete = 1 }) > 0;
        }

        private string GetPhysicalDeleteSqlText(string idKey)
        {
            var factory = this.client.GetCommandFactory();
            return factory
                .CreateDeleteBuilder()
                .From(this.TableName)
                .Where(factory.GetConditionFactory().EqualTo(this.PrimaryKey, idKey))
                .Build();
        }

        public virtual bool PhysicalDelete(TPrimary id) => this.client.ExecuteNonQuery(GetPhysicalDeleteSqlText(nameof(id)), new { id }) > 0;
        public virtual async Task<bool> PhysicalDeleteAsync(TPrimary id) => await client.ExecuteNonQueryAsync(GetPhysicalDeleteSqlText(nameof(id)), new { id }) > 0;

        public virtual bool Update(TEntity model)
        {
            return this.Update(new { model.ID }, model) > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity model)
        {
            return await this.UpdateAsync(new { model.ID }, model) > 0;
        }

        private (string, DynamicParameters) GetUpdateSqlText(object conditions, object entity)
        {
            var factory = this.client.GetCommandFactory();
            var builder = factory.CreateUpdateBuilder().Table(this.TableName);

            const string PREFIX_CONDITION = "__where_";
            const string PREFIX_TARGET = "__set_";

            var parameters = new DynamicParameters();
            foreach (var property in entity.GetType().GetProperties().Where(p => p.CanRead))
            {
                if (string.Equals(property.Name, this.PrimaryKey, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                var column = factory.GetDbObjectFactory().CreateColumn(property.Name);
                var parameter = factory.GetDbObjectFactory().CreateParameter($"{ PREFIX_CONDITION }{ property.Name }");
                builder = builder.Set(column.Name, parameter.Name);
                parameters.Add(parameter.SqlText, property.GetValue(conditions));
            }
            var where = default(IWhereBuilder);
            foreach (var property in conditions.GetType().GetProperties().Where(p => p.CanRead))
            {
                var column = factory.GetDbObjectFactory().CreateColumn(property.Name);
                var parameter = factory.GetDbObjectFactory().CreateParameter($"{ PREFIX_TARGET }{ property.Name }");
                var condition = factory.GetConditionFactory().EqualTo(column.Name, parameter.Name);
                where = where?.And(condition) ?? builder.Where(condition);
                parameters.Add(parameter.SqlText, property.GetValue(entity));
            }
            return (where.Build(), parameters);
        }

        protected virtual int Update(object condition, object entity)
        {
            var (sqlText, parameters) = this.GetUpdateSqlText(condition, entity);
            return this.client.ExecuteNonQuery(sqlText, parameters);
        }

        protected virtual async Task<int> UpdateAsync(object condition, object entity)
        {
            var (sqlText, parameters) = this.GetUpdateSqlText(condition, entity);
            return await this.client.ExecuteNonQueryAsync(sqlText, parameters);
        }
    }
}
