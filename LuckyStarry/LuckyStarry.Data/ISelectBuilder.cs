using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ISelectBuilder
    {
        ISelectBuilder Column(Objects.IDbColumn column);
        ISelectBuilder Columns(IEnumerable<Objects.IDbColumn> columns);

        IFromBuilder From(Objects.IDbTable table);
    }
}
