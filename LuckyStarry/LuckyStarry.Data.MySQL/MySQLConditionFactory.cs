using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLConditionFactory : IConditionFactory
    {
        ICondition IConditionFactory.EqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.EqualTo(column, parameter);
        ICondition IConditionFactory.GreaterThan(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.GreaterThan(column, parameter);
        ICondition IConditionFactory.GreaterThanOrEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.GreaterThanOrEqualTo(column, parameter);
        ICondition IConditionFactory.LessThan(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.LessThan(column, parameter);
        ICondition IConditionFactory.LessThanOrEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.LessThanOrEqualTo(column, parameter);
        ICondition IConditionFactory.NotEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.NotEqualTo(column, parameter);

        public virtual MySQLCondition EqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.EQ(column, parameter);
        public virtual MySQLCondition GreaterThan(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.GT(column, parameter);
        public virtual MySQLCondition GreaterThanOrEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.GTE(column, parameter);
        public virtual MySQLCondition LessThan(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.LT(column, parameter);
        public virtual MySQLCondition LessThanOrEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.LTE(column, parameter);
        public virtual MySQLCondition NotEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.NE(column, parameter);
    }
}
