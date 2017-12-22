using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLDbClient : DbClient
    {
        private readonly string connectionString;

        public MySQLDbClient(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override IDbConnection CreateConnection()
        {
            return this.CreateMySQLConnection();
        }

        public override ICommandFactory GetCommandFactory()
        {
            return this.GetMySQLCommandFactory();
        }

        public override async Task<IDbConnection> CreateConnectionAsync()
        {
            return await this.CreateMySQLConnectionAsync();
        }

        public virtual MySqlConnection CreateMySQLConnection()
        {
            return new MySqlConnection(this.connectionString);
        }

        public virtual MySQLCommandFactory GetMySQLCommandFactory()
        {
            return new MySQLCommandFactory();
        }

        public virtual async Task<MySqlConnection> CreateMySQLConnectionAsync()
        {
            return await Task.FromResult(this.CreateMySQLConnection());
        }
    }
}
