using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IIntoBuilder
    {
        IIntoColumnsBuilder Column(Objects.IDbColumn column);
        IIntoColumnsBuilder Columns(IEnumerable<Objects.IDbColumn> columns);
    }
}
