using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ITableBuilderUpdatable : ITableBuilder
    {
        ITableBuilder Set(string column, string paramter);
    }
}
