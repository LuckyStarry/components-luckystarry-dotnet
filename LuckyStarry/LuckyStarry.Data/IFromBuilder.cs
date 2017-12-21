using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IFromBuilder : ITableBuilder
    {
        new IWhereBuilderExtensible Where(ICondition condition);
    }
}
