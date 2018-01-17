using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public class SqlExecutionException : Exception
    {
        public SqlExecutionException(string sqlText, Exception innerException) : this($"SQL执行时出现异常，{ sqlText }。", sqlText, innerException) { }
        public SqlExecutionException(string message, string sqlText, Exception innerException)
            : base(message, innerException)
        {
            this.SqlText = sqlText;
        }

        public string SqlText { get; }
    }
}
