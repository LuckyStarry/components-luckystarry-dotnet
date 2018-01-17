using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStarry.Data.MySQL
{
    public interface IMySQLDbClient : IDbClient
    {
        MySqlConnection CreateMySQLConnection();
        MySQLCommandFactory GetMySQLCommandFactory();
        Task<MySqlConnection> CreateMySQLConnectionAsync();
    }
}
