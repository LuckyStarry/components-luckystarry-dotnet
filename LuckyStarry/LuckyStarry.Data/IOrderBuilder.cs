using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IOrderBuilder : ICompleteBuilder
    {
        IOrderBuilder ThenBy(string column);
        IOrderBuilder ThenByDescending(string column);
    }
}
