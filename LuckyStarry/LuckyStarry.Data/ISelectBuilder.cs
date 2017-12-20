using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ISelectBuilder
    {
        ISelectBuilder Column(string column);
        ISelectBuilder ColumnAs(string column, string alias);
        ISelectBuilder Columns(IEnumerable<string> columns);

        IFromBuilder From(string table);
        IFromBuilder FromAs(string table, string alias);
    }
}
