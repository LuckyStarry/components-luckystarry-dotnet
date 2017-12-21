using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IConditionFactory
    {
        ICondition EqualTo(string column, string parameter);
        ICondition NotEqualTo(string column, string parameter);
        ICondition LessThan(string column, string parameter);
        ICondition LessThanOrEqualTo(string column, string parameter);
        ICondition GreaterThan(string column, string parameter);
        ICondition GreaterThanOrEqualTo(string column, string parameter);
    }
}
