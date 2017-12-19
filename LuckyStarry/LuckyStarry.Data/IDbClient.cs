using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStarry.Data
{
    public interface IDbClient
    {
        string DbName { get; }
        ICommandBuilder CreateCommand(CommandType commandType);

        IDbConnection CreateConnection();
        T Execute<T>(Func<IDbConnection, T> func);
        int ExecuteNonQuery(string sqlText, object param = null);
        T ExecuteScalar<T>(string sqlText, object param = null);
        IEnumerable<T> Query<T>(string sqlText, object param = null);
        T QueryFirst<T>(string sqlText, object param = null);
        T QueryFirstOrDefault<T>(string sqlText, object param = null);

        T Transaction<T>(Func<IDbConnection, IDbTransaction, T> func);

        Task<IDbConnection> CreateConnectionAsync();
        Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> func);
        Task<int> ExecuteNonQueryAsync(string sqlText, object param = null);
        Task<T> ExecuteScalarAsync<T>(string sqlText, object param = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sqlText, object param = null);
        Task<T> QueryFirstAsync<T>(string sqlText, object param = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string sqlText, object param = null);

        Task<T> TransactionAsync<T>(Func<IDbConnection, IDbTransaction, Task<T>> func);
    }
}
