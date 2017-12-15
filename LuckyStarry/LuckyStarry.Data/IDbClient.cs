using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IDbClient
    {
        string DbName { get; }
        IDbConnection CreateConnection();
        T Execute<T>(Func<IDbConnection, T> func);
        int ExecuteNonQuery(string sqlText, object param = null);
        T ExecuteScalar<T>(string sqlText, object param = null);
        IEnumerable<T> Query<T>(string sqlText, object param = null);
        T QueryFirst<T>(string sqlText, object param = null);
        T QueryFirstOrDefault<T>(string sqlText, object param = null);

        T Transaction<T>(Func<IDbConnection, IDbTransaction, T> func);
    }
}
