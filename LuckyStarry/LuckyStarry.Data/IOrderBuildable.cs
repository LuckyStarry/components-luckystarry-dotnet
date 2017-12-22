using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IOrderBuildable
    {
        IOrderBuilder Order(Objects.IDbColumn column);
        IOrderBuilder OrderByDescending(Objects.IDbColumn column);
    }
}
