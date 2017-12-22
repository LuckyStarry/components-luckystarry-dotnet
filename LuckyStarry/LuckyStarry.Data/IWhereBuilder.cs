using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IWhereBuilder : ICompleteBuilder
    {
        IWhereBuilder And(ICondition condition);
        IWhereBuilder Or(ICondition condition);
    }
}
