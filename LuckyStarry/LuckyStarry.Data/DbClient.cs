using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LuckyStarry.Data
{
    public abstract class DbClient : IDbClient
    {
        public abstract ICommandFactory GetCommandFactory();

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

        private T Execute<T>(Func<IDbConnection, string, object, T> func, string sqlText, object parameter)
        {
            try
            {
                return this.Execute(connection => func(connection, sqlText, parameter));
            }
            catch (Exception exception)
            {
                throw new SqlExecutionException(sqlText, exception);
            }
        }
        private async Task<T> ExecuteAsync<T>(Func<IDbConnection, string, object, Task<T>> func, string sqlText, object parameter)
        {
            try
            {
                return await this.ExecuteAsync(connection => func(connection, sqlText, parameter));
            }
            catch (Exception exception)
            {
                throw new SqlExecutionException(sqlText, exception);
            }
        }

        public virtual IEnumerable<T> Query<T>(string sqlText, object parameter = null) => this.Execute((connection, sql, param) => connection.Query<T>(sql, param), sqlText, parameter);
        public virtual T QueryFirst<T>(string sqlText, object parameter = null) => this.Execute((connection, sql, param) => connection.QueryFirst<T>(sql, param), sqlText, parameter);
        public virtual T QueryFirstOrDefault<T>(string sqlText, object parameter = null) => this.Execute((connection, sql, param) => connection.QueryFirstOrDefault<T>(sql, param), sqlText, parameter);
        public virtual T ExecuteScalar<T>(string sqlText, object parameter = null) => this.Execute((connection, sql, param) => connection.ExecuteScalar<T>(sql, param), sqlText, parameter);
        public virtual int ExecuteNonQuery(string sqlText, object parameter = null) => this.Execute((connection, sql, param) => connection.Execute(sql, param), sqlText, parameter);

        public virtual async Task<IEnumerable<T>> QueryAsync<T>(string sqlText, object parameter = null) => await this.ExecuteAsync((connection, sql, param) => connection.QueryAsync<T>(sql, param), sqlText, parameter);
        public virtual async Task<T> QueryFirstAsync<T>(string sqlText, object parameter = null) => await this.ExecuteAsync((connection, sql, param) => connection.QueryFirstAsync<T>(sql, param), sqlText, parameter);
        public virtual async Task<T> QueryFirstOrDefaultAsync<T>(string sqlText, object parameter = null) => await this.ExecuteAsync((connection, sql, param) => connection.QueryFirstOrDefaultAsync<T>(sql, param), sqlText, parameter);
        public virtual async Task<int> ExecuteNonQueryAsync(string sqlText, object parameter = null) => await this.ExecuteAsync((connection, sql, param) => connection.ExecuteAsync(sql, param), sqlText, parameter);
        public virtual async Task<T> ExecuteScalarAsync<T>(string sqlText, object parameter = null) => await this.ExecuteAsync((connection, sql, param) => connection.ExecuteScalarAsync<T>(sql, param), sqlText, parameter);

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
