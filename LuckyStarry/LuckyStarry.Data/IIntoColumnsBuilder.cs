using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IIntoColumnsBuilder : IIntoBuilder
    {
        IIntoValuesBuilder Value(string parameter);
        IIntoValuesBuilder Values(IEnumerable<string> parameters);
    }
}
