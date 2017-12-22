using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IIntoColumnsBuilder : IIntoBuilder
    {
        IIntoValuesBuilder Value(Objects.IDbParameter parameter);
        IIntoValuesBuilder Values(IEnumerable<Objects.IDbParameter> parameters);
    }
}
