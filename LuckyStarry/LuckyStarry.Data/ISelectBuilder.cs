using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ISelectBuilder : ICommandBuilder
    {
        ISelectBuilder Column(string column);
        ISelectBuilder ColumnAs(string column, string alias);
        ISelectBuilder Columns(IEnumerable<string> columns);
    }
}
