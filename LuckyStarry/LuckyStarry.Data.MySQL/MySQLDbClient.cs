using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLDbClient : DbClient
    {
        private readonly string connectionString;

        public MySQLDbClient(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override ICommandBuilder CreateCommand(CommandType commandType)
        {
            throw new NotImplementedException();
        }

        public override IDbConnection CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
}
