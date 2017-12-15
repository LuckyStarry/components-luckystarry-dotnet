using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.DependencyInjection;

namespace LuckyStarry.Data
{
    public class DbClient : IDbClient
    {
        private IServiceProvider services { get; }
        public string DbName { get; }

        public DbClient(IServiceCollection services, string dbName)
        {
            this.DbName = dbName;
        }

        public static T Execute<T>(IDbConnection connection, Func<IDbConnection, T> func)
        {
            using (connection)
            {
                return func(connection);
            }
        }

        public virtual IDbConnection CreateConnection()
        {
        }
        public virtual T Execute<T>(Func<IDbConnection, T> func)
        {
            return DbClient.Execute<T>(this.CreateConnection(), func);
        }

        public virtual IEnumerable<T> Query<T>(string sqlText, object param = null)
        {
            return this.Execute(connection => connection.Query<T>(sqlText, param));
        }
        public virtual T QueryFirst<T>(string sqlText, object param = null)
        {
            return this.Execute(connection => connection.QueryFirst<T>(sqlText, param));
        }
        public virtual T QueryFirstOrDefault<T>(string sqlText, object param = null)
        {
            return this.Execute(connection => connection.QueryFirstOrDefault<T>(sqlText, param));
        }
        public virtual T ExecuteScalar<T>(string sqlText, object param = null)
        {
            return this.Execute(connection => connection.ExecuteScalar<T>(sqlText, param));
        }
        public virtual int ExecuteNonQuery(string sqlText, object param = null)
        {
            return this.Execute(connection => connection.Execute(sqlText, param));
        }

        public virtual T Transaction<T>(Func<IDbConnection, IDbTransaction, T> func)
        {
            return this.Execute(connection =>
            {
                var transaction = connection.BeginTransaction();
                try
                {
                    var result = func(connection, transaction);
                    transaction.Commit();
                    return result;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            });
        }
    }
}
