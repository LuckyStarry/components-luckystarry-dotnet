using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IOrderBuildable
    {
        IOrderBuilder Order(string column);
        IOrderBuilder OrderByDescending(string column);
    }
}
