using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Services
{
    public class DbServiceException : Exception
    {
        public DbServiceException(string sqlText)
        {
            this.SqlText = sqlText;
        }

        public DbServiceException(string sqlText, string message) : base(message)
        {
            this.SqlText = sqlText;
        }

        public string SqlText { get; }
    }
}
