using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LuckyStarry.Data
{
    public abstract class DbClient : IDbClient
    {
        public abstract ICommandBuilder CreateCommand(CommandType commandType);

        public static T Execute<T>(IDbConnection connection, Func<IDbConnection, T> func)
        {
            using (connection)
            {
                return func(connection);
            }
        }
        public virtual T Execute<T>(Func<IDbConnection, T> func) => DbClient.Execute<T>(this.CreateConnection(), func);
        public static async Task<T> ExecuteAsync<T>(IDbConnection connection, Func<IDbConnection, Task<T>> func)
        {
            using (connection)
            {
                return await func(connection);
            }
        }
        public virtual async Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> func) => await DbClient.ExecuteAsync<T>(await this.CreateConnectionAsync(), func);

        public abstract IDbConnection CreateConnection();
        public virtual async Task<IDbConnection> CreateConnectionAsync() => await Task.FromResult(this.CreateConnection());

        public virtual IEnumerable<T> Query<T>(string sqlText, object param = null) => this.Execute(connection => connection.Query<T>(sqlText, param));
        public virtual T QueryFirst<T>(string sqlText, object param = null) => this.Execute(connection => connection.QueryFirst<T>(sqlText, param));
        public virtual T QueryFirstOrDefault<T>(string sqlText, object param = null) => this.Execute(connection => connection.QueryFirstOrDefault<T>(sqlText, param));
        public virtual T ExecuteScalar<T>(string sqlText, object param = null) => this.Execute(connection => connection.ExecuteScalar<T>(sqlText, param));
        public virtual int ExecuteNonQuery(string sqlText, object param = null) => this.Execute(connection => connection.Execute(sqlText, param));

        public virtual async Task<IEnumerable<T>> QueryAsync<T>(string sqlText, object param = null) => await this.ExecuteAsync(connection => connection.QueryAsync<T>(sqlText, param));
        public virtual async Task<T> QueryFirstAsync<T>(string sqlText, object param = null) => await this.ExecuteAsync(connection => connection.QueryFirstAsync<T>(sqlText, param));
        public virtual async Task<T> QueryFirstOrDefaultAsync<T>(string sqlText, object param = null) => await this.ExecuteAsync(connection => connection.QueryFirstOrDefaultAsync<T>(sqlText, param));
        public virtual async Task<int> ExecuteNonQueryAsync(string sqlText, object param = null) => await this.ExecuteAsync(connection => connection.ExecuteAsync(sqlText, param));
        public virtual async Task<T> ExecuteScalarAsync<T>(string sqlText, object param = null) => await this.ExecuteAsync(connection => connection.ExecuteScalarAsync<T>(sqlText, param));

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
        public virtual async Task<T> TransactionAsync<T>(Func<IDbConnection, IDbTransaction, Task<T>> func)
        {
            return await this.ExecuteAsync(async connection =>
            {
                var transaction = connection.BeginTransaction();
                try
                {
                    var result = await func(connection, transaction);
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
