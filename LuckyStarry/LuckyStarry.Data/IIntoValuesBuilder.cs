using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IIntoValuesBuilder : ICompleteBuilder
    {
        IIntoValuesBuilder Value(string parameter);
        IIntoValuesBuilder Values(IEnumerable<string> parameters);
    }
}
