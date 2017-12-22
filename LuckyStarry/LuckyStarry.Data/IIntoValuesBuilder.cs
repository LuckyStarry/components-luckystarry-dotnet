using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IIntoValuesBuilder : ICompleteBuilder
    {
        IIntoValuesBuilder Value(Objects.IDbParameter parameter);
        IIntoValuesBuilder Values(IEnumerable<Objects.IDbParameter> parameters);
    }
}
