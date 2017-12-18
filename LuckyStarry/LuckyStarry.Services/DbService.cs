using Dapper;
using LuckyStarry.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Services
{
    public abstract class DbService<TEntity> : Service, IDbService<TEntity>
       where TEntity : Models.IEntity
    {
        private readonly ISqlTextDecorator decorator;
        private readonly IDbClientFactory factory;

        public DbService(ISqlTextDecorator decorator, IDbClientFactory factory)
        {
            this.decorator = decorator;
            this.factory = factory;
        }

        public virtual string[] Columns => typeof(TEntity).GetProperties().Select(p => p.Name).ToArray();

        public abstract string DatabaseName { get; }

        public virtual string TableName => typeof(TEntity).Name;

        public virtual IEnumerable<TEntity> GetAll()
        {
            var sqlText = this.decorator.Comment($@"
SELECT { string.Join(",", this.Columns.Select(c => this.decorator.ColumnName(c))) }
  FROM { this.decorator.TableName(this.TableName) }
", $"{ nameof(DbService<TEntity>) }.{ nameof(GetAll) }");

            return this.factory.Create(this.DatabaseName).Query<TEntity>(sqlText);
        }
    }

    public abstract class DbService<TEntity, TPrimary> : DbService<TEntity>, IDbService<TEntity, TPrimary>
       where TEntity : Models.IEntity<TPrimary>
    {
        private readonly ISqlTextDecorator decorator;
        private readonly IDbClientFactory factory;

        public DbService(ISqlTextDecorator decorator, IDbClientFactory factory) : base(decorator, factory)
        {
            this.decorator = decorator;
            this.factory = factory;
        }

        public virtual string PrimaryKey => nameof(Models.IEntity<TPrimary>.ID);

        public virtual TEntity GetById(TPrimary id)
        {
            var sqlText = this.decorator.Comment($@"
SELECT { string.Join(",", this.Columns.Select(c => this.decorator.ColumnName(c))) }
  FROM { this.decorator.TableName(this.TableName) }
 WHERE { this.decorator.ColumnName(this.PrimaryKey) } = { this.decorator.ParameterName(nameof(id)) }
", $"{ nameof(DbService<TEntity, TPrimary>) }.{ nameof(GetById) }");

            return this.factory.Create(this.DatabaseName).QueryFirstOrDefault<TEntity>(sqlText, new { id });
        }

        public virtual TPrimary Insert(TEntity model)
        {
            var sqlText = this.decorator.Comment($@"
INSERT INTO  { this.decorator.TableName(this.TableName) }
            ({ string.Join(",", this.Columns.Select(c => this.decorator.ColumnName(c))) })
     VALUES ({ string.Join(",", this.Columns.Select(c => this.decorator.ParameterName(c))) })
", $"{ nameof(DbService<TEntity, TPrimary>) }.{ nameof(Insert) }");

            var count = this.factory.Create(this.DatabaseName).ExecuteNonQuery(sqlText, model);
            return count > 0 ? model.ID : throw new InsertFailedException(sqlText);
        }

        public virtual bool LogicalDelete(TPrimary id)
        {
            return this.Update(new { ID = id }, new { LogicalDelete = 1 }) > 0;
        }

        public virtual bool PhysicalDelete(TPrimary id)
        {
            var sqlText = this.decorator.Comment($@"
DELETE { this.decorator.TableName(this.TableName) }
 WHERE { this.decorator.ColumnName(this.PrimaryKey) } = { this.decorator.ParameterName(nameof(id)) }
", $"{ nameof(DbService<TEntity, TPrimary>) }.{ nameof(GetById) }");

            return this.factory.Create(this.DatabaseName).ExecuteNonQuery(sqlText, new { id }) > 0;
        }

        public virtual bool Update(TEntity model)
        {
            return this.Update(new { model.ID }, model) > 0;
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

            return this.factory.Create(this.DatabaseName).ExecuteNonQuery(sqlText, parameters);
        }
    }
}
