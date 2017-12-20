using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ITableBuilder : ICompleteBuilder
    {
        IWhereBuilder Where(ISqlCondition condition);
    }
}
