using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions
{
    class BinaryCondition : MySQLCondition
    {
        private readonly string left;
        private readonly string right;
        private readonly Operations.BinaryOperation operation;

        public BinaryCondition(string left, string right, Operations.BinaryOperation operation)
        {
            this.left = left;
            this.right = right;
            this.operation = operation;
        }

        public override string Build() => this.operation.Compile(left, right);
    }
}
