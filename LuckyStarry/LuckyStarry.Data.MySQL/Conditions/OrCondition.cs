using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions
{
    public class OrCondition : ComposeCondition
    {
        protected internal OrCondition(ICondition previous, ICondition condition) : base(previous, condition)
        {
        }

        public override string ComposeType => "OR";
    }
}
