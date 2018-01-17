using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IFromBuilder : ITableBuilder, IOrderBuildable
    {
        new IWhereBuilderExtensible Where(ICondition condition);
    }
}
