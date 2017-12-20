﻿using Dapper;
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

        public virtual TPrimary Insert(TEntity model)
        {
            var sqlText = this.decorator.Comment($@"
INSERT INTO  { this.decorator.TableName(this.TableName) }
            ({ string.Join(",", this.Columns.Select(c => this.decorator.ColumnName(c))) })
     VALUES ({ string.Join(",", this.Columns.Select(c => this.decorator.ParameterName(c))) })
", $"{ nameof(DbService<TEntity, TPrimary>) }.{ nameof(Insert) }");

            var count = this.factory.Create().ExecuteNonQuery(sqlText, model);
            return count > 0 ? model.ID : throw new InsertFailedException(sqlText);
        }

        public virtual async Task<TPrimary> InsertAsync(TEntity model)
        {
            var sqlText = this.decorator.Comment($@"
INSERT INTO  { this.decorator.TableName(this.TableName) }
            ({ string.Join(",", this.Columns.Select(c => this.decorator.ColumnName(c))) })
     VALUES ({ string.Join(",", this.Columns.Select(c => this.decorator.ParameterName(c))) })
", $"{ nameof(DbService<TEntity, TPrimary>) }.{ nameof(InsertAsync) }");

            var client = await this.factory.CreateAsync();
            var count = await client.ExecuteNonQueryAsync(sqlText, model);
            return count > 0 ? model.ID : throw new InsertFailedException(sqlText);
        }

        public virtual bool LogicalDelete(TPrimary id)
        {
            return this.Update(new { ID = id }, new { LogicalDelete = 1 }) > 0;
        }

        public virtual async Task<bool> LogicalDeleteAsync(TPrimary id)
        {
            return await this.UpdateAsync(new { ID = id }, new { LogicalDelete = 1 }) > 0;
        }

        public virtual bool PhysicalDelete(TPrimary id)
        {
            var sqlText = this.decorator.Comment($@"
DELETE { this.decorator.TableName(this.TableName) }
 WHERE { this.decorator.ColumnName(this.PrimaryKey) } = { this.decorator.ParameterName(nameof(id)) }
", $"{ nameof(DbService<TEntity, TPrimary>) }.{ nameof(GetById) }");

            return this.factory.Create().ExecuteNonQuery(sqlText, new { id }) > 0;
        }

        public virtual async Task<bool> PhysicalDeleteAsync(TPrimary id)
        {
            var sqlText = this.decorator.Comment($@"
DELETE { this.decorator.TableName(this.TableName) }
 WHERE { this.decorator.ColumnName(this.PrimaryKey) } = { this.decorator.ParameterName(nameof(id)) }
", $"{ nameof(DbService<TEntity, TPrimary>) }.{ nameof(GetById) }");

            var client = await this.factory.CreateAsync();
            var count = await client.ExecuteNonQueryAsync(sqlText, new { id });
            return count > 0;
        }

        public virtual bool Update(TEntity model)
        {
            return this.Update(new { model.ID }, model) > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity model)
        {
            return await this.UpdateAsync(new { model.ID }, model) > 0;
        }

        protected virtual int Update(object condition, object entity)
        {
            var conditions = new List<string>();
            var targets = new List<string>();
            const string PREFIX_CONDITION = "__where_";
            const string PREFIX_TARGET = "__set_";

            var parameters = new DynamicParameters();
            foreach (var property in condition.GetType().GetProperties().Where(p => p.CanRead))
            {
                conditions.Add(property.Name);
                parameters.Add(this.decorator.ParameterName($"{ PREFIX_CONDITION }{ property.Name }"), property.GetValue(condition));
            }
            foreach (var property in entity.GetType().GetProperties().Where(p => p.CanRead))
            {
                if (string.Equals(property.Name, this.PrimaryKey, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                targets.Add(property.Name);
                parameters.Add(this.decorator.ParameterName($"{ PREFIX_TARGET }{ property.Name }"), property.GetValue(condition));
            }

            var sqlText = this.decorator.Comment($@"
UPDATE { this.decorator.TableName(this.TableName) }
   SET { string.Join(",", targets.Select(c => $"{ this.decorator.ColumnName($"{ c }") } = { this.decorator.ParameterName($"{ PREFIX_TARGET }{ c }") }")) }
 WHERE { string.Join(",", conditions.Select(c => $"{ this.decorator.ColumnName($"{ c }") } = { this.decorator.ParameterName($"{ PREFIX_CONDITION }{ c }") }")) }
", $"{ nameof(DbService<TEntity, TPrimary>) }.{ nameof(Update) }");

            return this.factory.Create().ExecuteNonQuery(sqlText, parameters);
        }

        protected virtual async Task<int> UpdateAsync(object condition, object entity)
        {
            var conditions = new List<string>();
            var targets = new List<string>();
            const string PREFIX_CONDITION = "__where_";
            const string PREFIX_TARGET = "__set_";

            var parameters = new DynamicParameters();
            foreach (var property in condition.GetType().GetProperties().Where(p => p.CanRead))
            {
                conditions.Add(property.Name);
                parameters.Add(this.decorator.ParameterName($"{ PREFIX_CONDITION }{ property.Name }"), property.GetValue(condition));
            }
            foreach (var property in entity.GetType().GetProperties().Where(p => p.CanRead))
            {
                if (string.Equals(property.Name, this.PrimaryKey, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                targets.Add(property.Name);
                parameters.Add(this.decorator.ParameterName($"{ PREFIX_TARGET }{ property.Name }"), property.GetValue(condition));
            }

            var sqlText = this.decorator.Comment($@"
UPDATE { this.decorator.TableName(this.TableName) }
   SET { string.Join(",", targets.Select(c => $"{ this.decorator.ColumnName($"{ c }") } = { this.decorator.ParameterName($"{ PREFIX_TARGET }{ c }") }")) }
 WHERE { string.Join(",", conditions.Select(c => $"{ this.decorator.ColumnName($"{ c }") } = { this.decorator.ParameterName($"{ PREFIX_CONDITION }{ c }") }")) }
", $"{ nameof(DbService<TEntity, TPrimary>) }.{ nameof(UpdateAsync) }");

            var client = await this.factory.CreateAsync();
            return await client.ExecuteNonQueryAsync(sqlText, parameters);
        }
    }
}
