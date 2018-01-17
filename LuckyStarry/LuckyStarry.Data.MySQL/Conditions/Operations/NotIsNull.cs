using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions.Operations
{
    class NotIsNull : UnaryOperation
    {
        public override string OperatorSymbol => "IS NOT NULL";

        public override string Compile(string expression)
        {
            return $"{ expression } { this.OperatorSymbol }";
        }
    }
}
