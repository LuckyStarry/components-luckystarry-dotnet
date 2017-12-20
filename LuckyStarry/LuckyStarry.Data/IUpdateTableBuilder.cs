using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IUpdateTableBuilder
    {
        IUpdateTableBuilder Set(string column, string paramter);

        IWhereBuilder Where(ISqlCondition condition);
    }
}
