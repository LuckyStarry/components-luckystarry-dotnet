using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLConditionFactory : IConditionFactory
    {
        ICondition IConditionFactory.EqualTo(string column, string parameter) => this.EqualTo(column, parameter);
        ICondition IConditionFactory.GreaterThan(string column, string parameter) => this.GreaterThan(column, parameter);
        ICondition IConditionFactory.GreaterThanOrEqualTo(string column, string parameter) => this.GreaterThanOrEqualTo(column, parameter);
        ICondition IConditionFactory.LessThan(string column, string parameter) => this.LessThan(column, parameter);
        ICondition IConditionFactory.LessThanOrEqualTo(string column, string parameter) => this.LessThanOrEqualTo(column, parameter);
        ICondition IConditionFactory.NotEqualTo(string column, string parameter) => this.NotEqualTo(column, parameter);

        public virtual MySQLCondition EqualTo(string column, string parameter) => MySQLCondition.EQ(column, parameter);
        public virtual MySQLCondition GreaterThan(string column, string parameter) => MySQLCondition.GT(column, parameter);
        public virtual MySQLCondition GreaterThanOrEqualTo(string column, string parameter) => MySQLCondition.GTE(column, parameter);
        public virtual MySQLCondition LessThan(string column, string parameter) => MySQLCondition.LT(column, parameter);
        public virtual MySQLCondition LessThanOrEqualTo(string column, string parameter) => MySQLCondition.LTE(column, parameter);
        public virtual MySQLCondition NotEqualTo(string column, string parameter) => MySQLCondition.NE(column, parameter);
    }
}
