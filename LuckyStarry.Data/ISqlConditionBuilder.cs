using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ISqlConditionBuilder
    {
        ISqlConditionBuilder And(string column, string parameter);
        ISqlConditionBuilder Or(string column, string parameter);

        ISqlConditionBuilder And(ISqlConditionBuilder condition);
        ISqlConditionBuilder Or(ISqlConditionBuilder condition);

        string Compile();
    }
}
