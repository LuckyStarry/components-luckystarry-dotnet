using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IOrderBuildable
    {
        IOrderBuilder OrderBy(Objects.IDbColumn column);
        IOrderBuilder OrderByDescending(Objects.IDbColumn column);
    }
}
