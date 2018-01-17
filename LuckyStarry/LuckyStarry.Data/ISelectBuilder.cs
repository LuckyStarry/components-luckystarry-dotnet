using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ISelectBuilder
    {
        ISelectBuilderColumnsSelected Column(Objects.IDbColumn column);
        ISelectBuilderColumnsSelected Columns(IEnumerable<Objects.IDbColumn> columns);

        IFromBuilder From(Objects.IDbTable table);
    }
}
