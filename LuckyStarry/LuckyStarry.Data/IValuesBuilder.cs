using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IValuesBuilder : ICompleteBuilder
    {
        IValuesBuilder Value(string paramter);
        IValuesBuilder Value(IEnumerable<string> paramters);
    }
}
