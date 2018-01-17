using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions.Operations
{
    abstract class BinaryOperation : MySQLConditionOperation
    {
        public virtual string Compile(string left, string right)
        {
            return $"{ left } { this.OperatorSymbol } { right }";
        }

        public virtual MySQLCondition Create(string left, string right)
        {
            return new BinaryCondition(left, right, this);
        }
    }
}
