using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Services
{
    public class InsertFailedException : DbServiceException
    {
        public InsertFailedException(string sqlText) : base(sqlText)
        {
        }

        public InsertFailedException(string sqlText, string message) : base(sqlText, message)
        {
        }
    }
}
