using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Services
{
    public class UpdateFailedException : DbServiceException
    {
        public UpdateFailedException(string sqlText) : base(sqlText)
        {
        }

        public UpdateFailedException(string sqlText, string message) : base(sqlText, message)
        {
        }
    }
}
