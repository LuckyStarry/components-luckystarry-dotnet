using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLNoneSetException : MySQLBuildException
    {
        public MySQLNoneSetException() : this("MySQL构建更新语句时缺少SET节点") { }
        public MySQLNoneSetException(string message) : base(message)
        {
        }
    }
}
