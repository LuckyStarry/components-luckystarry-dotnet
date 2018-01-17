using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions
{
    public class AndCondition : ComposeCondition
    {
        protected internal AndCondition(ICondition previous, ICondition condition) : base(previous, condition)
        {
        }

        public override string ComposeType => "AND";
    }
}
