using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Conditions
{
    class NotCondition : ComposeCondition
    {
        public NotCondition(ICondition condition) : base(condition)
        {
        }

        public override string ComposeType => "NOT";
    }
}
