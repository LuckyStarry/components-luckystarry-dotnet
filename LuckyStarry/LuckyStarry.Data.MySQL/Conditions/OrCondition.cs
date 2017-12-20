using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions
{
    class OrCondition : ComposeCondition
    {
        public OrCondition(ISqlCondition condition) : base(condition)
        {
        }

        public override string ComposeType => "OR";
    }
}
