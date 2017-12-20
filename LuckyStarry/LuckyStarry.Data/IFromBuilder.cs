using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IFromBuilder : ICompleteBuilder
    {
        IWhereBuilder Where(ISqlCondition condition);
    }
}
