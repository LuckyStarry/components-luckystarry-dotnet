using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ISqlConditionFactory
    {
        ISqlCondition EqualTo(string column, string parameter);
        ISqlCondition NotEqualTo(string column, string parameter);
        ISqlCondition LessThan(string column, string parameter);
        ISqlCondition LessThanOrEqualTo(string column, string parameter);
        ISqlCondition GreaterThan(string column, string parameter);
        ISqlCondition GreaterThanOrEqualTo(string column, string parameter);
    }
}
