using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLConditionFactory : ISqlConditionFactory
    {
        ISqlCondition ISqlConditionFactory.EqualTo(string column, string parameter) => this.EqualTo(column, parameter);
        ISqlCondition ISqlConditionFactory.GreaterThan(string column, string parameter) => this.GreaterThan(column, parameter);
        ISqlCondition ISqlConditionFactory.GreaterThanOrEqualTo(string column, string parameter) => this.GreaterThanOrEqualTo(column, parameter);
        ISqlCondition ISqlConditionFactory.LessThan(string column, string parameter) => this.LessThan(column, parameter);
        ISqlCondition ISqlConditionFactory.LessThanOrEqualTo(string column, string parameter) => this.LessThanOrEqualTo(column, parameter);
        ISqlCondition ISqlConditionFactory.NotEqualTo(string column, string parameter) => this.NotEqualTo(column, parameter);

        public virtual MySQLCondition EqualTo(string column, string parameter) => MySQLCondition.EQ(column, parameter);
        public virtual MySQLCondition GreaterThan(string column, string parameter) => MySQLCondition.GT(column, parameter);
        public virtual MySQLCondition GreaterThanOrEqualTo(string column, string parameter) => MySQLCondition.GTE(column, parameter);
        public virtual MySQLCondition LessThan(string column, string parameter) => MySQLCondition.LT(column, parameter);
        public virtual MySQLCondition LessThanOrEqualTo(string column, string parameter) => MySQLCondition.LTE(column, parameter);
        public virtual MySQLCondition NotEqualTo(string column, string parameter) => MySQLCondition.NE(column, parameter);
    }
}
