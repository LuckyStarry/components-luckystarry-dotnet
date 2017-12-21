using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IIntoColumnsBuilder : IIntoBuilder
    {
        IIntoValuesBuilder Values(string paramters);
        IIntoValuesBuilder Values(IEnumerable<string> paramters);
    }
}
