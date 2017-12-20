using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions.Operations
{
    abstract class UnaryOperation : MySQLConditionOperation
    {
        public virtual string Compile(string expression)
        {
            return $"{ this.OperatorSymbol } { expression }";
        }
    }
}
