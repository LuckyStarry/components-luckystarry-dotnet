using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IConditionFactory
    {
        ICondition EqualTo(Objects.IDbColumn column, Objects.IDbParameter parameter);
        ICondition NotEqualTo(Objects.IDbColumn column, Objects.IDbParameter parameter);
        ICondition LessThan(Objects.IDbColumn column, Objects.IDbParameter parameter);
        ICondition LessThanOrEqualTo(Objects.IDbColumn column, Objects.IDbParameter parameter);
        ICondition GreaterThan(Objects.IDbColumn column, Objects.IDbParameter parameter);
        ICondition GreaterThanOrEqualTo(Objects.IDbColumn column, Objects.IDbParameter parameter);

        ICondition IsNull(Objects.IDbColumn column);
        ICondition NotIsNull(Objects.IDbColumn column);
    }
}
