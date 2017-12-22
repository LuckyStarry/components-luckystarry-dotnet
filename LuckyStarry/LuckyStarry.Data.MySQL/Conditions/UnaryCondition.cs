using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions
{
    class UnaryCondition : MySQLCondition
    {
        private readonly string expression;
        private readonly Operations.UnaryOperation operation;

        public UnaryCondition(string expression, Operations.UnaryOperation operation)
        {
            this.expression = expression;
            this.operation = operation;
        }

        public override string Build() => this.operation.Compile(this.expression);
    }
}
