using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStarry.Data
{
    public interface IDbClient
    {
        ICommandFactory GetCommandFactory();

        IDbConnection CreateConnection();
        T Execute<T>(Func<IDbConnection, T> func);
        int ExecuteNonQuery(string sqlText, object parameter = null);
        T ExecuteScalar<T>(string sqlText, object parameter = null);
        IEnumerable<T> Query<T>(string sqlText, object parameter = null);
        T QueryFirst<T>(string sqlText, object parameter = null);
        T QueryFirstOrDefault<T>(string sqlText, object parameter = null);

        T Transaction<T>(Func<IDbConnection, IDbTransaction, T> func);

        Task<IDbConnection> CreateConnectionAsync();
        Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> func);
        Task<int> ExecuteNonQueryAsync(string sqlText, object parameter = null);
        Task<T> ExecuteScalarAsync<T>(string sqlText, object parameter = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sqlText, object parameter = null);
        Task<T> QueryFirstAsync<T>(string sqlText, object parameter = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string sqlText, object parameter = null);

        Task<T> TransactionAsync<T>(Func<IDbConnection, IDbTransaction, Task<T>> func);
    }
}
