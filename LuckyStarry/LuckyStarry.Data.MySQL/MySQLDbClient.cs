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

        public override IDbConnection CreateConnection()
        {
            throw new NotImplementedException();
        }

        public override ICommandFactory GetCommandFactory()
        {
            throw new NotImplementedException();
        }
    }
}
