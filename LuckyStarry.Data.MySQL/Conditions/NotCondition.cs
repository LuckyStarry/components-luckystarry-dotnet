using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions
{
    public class NotCondition : MySQLCondition
    {
        private readonly ICondition condition;

        protected internal NotCondition(ICondition condition)
        {
            this.condition = condition;
        }

        public override string Build()
        {
            return $"NOT ({ this.condition.Build() })";
        }
    }
}
