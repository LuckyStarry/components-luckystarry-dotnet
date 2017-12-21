using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions
{
    class AndCondition : ComposeCondition
    {
        public AndCondition(ICondition condition) : base(condition)
        {
        }

        public override string ComposeType => "AND";
    }
}
