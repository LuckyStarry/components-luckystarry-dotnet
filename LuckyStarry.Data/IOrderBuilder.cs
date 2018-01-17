using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IOrderBuilder : ICompleteBuilder
    {
        IOrderBuilder ThenBy(Objects.IDbColumn column);
        IOrderBuilder ThenByDescending(Objects.IDbColumn column);
    }
}
