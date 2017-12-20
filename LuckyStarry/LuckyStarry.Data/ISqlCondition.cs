using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ISqlCondition
    {
        ISqlCondition And(ISqlCondition condition);
        ISqlCondition Or(ISqlCondition condition);

        string Build();
    }
}
