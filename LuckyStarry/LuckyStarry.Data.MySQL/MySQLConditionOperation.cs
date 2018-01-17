using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    abstract class MySQLConditionOperation
    {
        public abstract string OperatorSymbol { get; }
    }
}
