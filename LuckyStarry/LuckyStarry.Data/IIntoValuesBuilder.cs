using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IIntoValuesBuilder : ICompleteBuilder
    {
        IIntoValuesBuilder Values(string paramter);
        IIntoValuesBuilder Values(IEnumerable<string> paramters);
    }
}
