using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLBuildException : Exception
    {
        public MySQLBuildException() : this("MySQL语句构建失败") { }
        public MySQLBuildException(string message) : base(message)
        {
        }
    }
}
