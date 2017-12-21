using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IIntoBuilder
    {
        IIntoColumnsBuilder Column(string column);
        IIntoColumnsBuilder Columns(IEnumerable<string> columns);
    }
}
