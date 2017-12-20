using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions
{
    abstract class ComposeCondition : MySQLCondition
    {
        private readonly ISqlCondition condition;

        public ComposeCondition(ISqlCondition condition)
        {
            this.condition = condition;
        }

        public abstract string ComposeType { get; }

        public override string Build()
        {
            return $"{ this.ComposeType } ({ this.condition.Build() })";
        }
    }
}
