using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions
{
    public abstract class ComposeCondition : MySQLCondition
    {
        private readonly ICondition condition;
        private readonly ICondition previous;

        protected internal ComposeCondition(ICondition previous, ICondition condition)
        {
            this.previous = previous;
            this.condition = condition;
        }

        public abstract string ComposeType { get; }

        public override string Build()
        {
            return $"({ this.previous.Build() }) { this.ComposeType } ({ this.condition.Build() })";
        }
    }
}
