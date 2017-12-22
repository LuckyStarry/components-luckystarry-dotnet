using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ITableBuilderUpdatable : ITableBuilder
    {
        ITableBuilderUpdatable Set(Objects.IDbColumn column, Objects.IDbParameter parameter);
    }
}
