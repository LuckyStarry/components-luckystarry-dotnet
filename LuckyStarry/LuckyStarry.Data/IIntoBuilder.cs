using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IIntoBuilder
    {
        IIntoBuilder Column(string column);
        IIntoBuilder Columns(IEnumerable<string> columns);

        IValuesBuilder Values(string paramters);
        IValuesBuilder Values(IEnumerable<string> paramters);
    }
}
