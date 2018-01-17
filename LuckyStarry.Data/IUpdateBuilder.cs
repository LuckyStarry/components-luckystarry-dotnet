using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IUpdateBuilder
    {
        ITableBuilderUpdatable Table(Objects.IDbTable table);
    }
}
