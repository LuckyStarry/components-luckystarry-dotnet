using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public abstract class MySQLCondition : ICondition
    {
        ICondition ICondition.And(ICondition condition) => this.And(condition);
        ICondition ICondition.Or(ICondition condition) => this.Or(condition);

        public virtual MySQLCondition And(ICondition condition) => new Conditions.AndCondition(condition);
        public virtual MySQLCondition Or(ICondition condition) => new Conditions.OrCondition(condition);

        public static MySQLCondition EQ(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => BinaryCondition<Conditions.Operations.Equal>(column, parameter);
        public static MySQLCondition NE(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => BinaryCondition<Conditions.Operations.NotEqual>(column, parameter);
        public static MySQLCondition LT(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => BinaryCondition<Conditions.Operations.LessThan>(column, parameter);
        public static MySQLCondition LTE(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => BinaryCondition<Conditions.Operations.LessThanOrEqual>(column, parameter);
        public static MySQLCondition GT(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => BinaryCondition<Conditions.Operations.GreaterThan>(column, parameter);
        public static MySQLCondition GTE(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => BinaryCondition<Conditions.Operations.GreaterThanOrEqual>(column, parameter);

        private static MySQLCondition BinaryCondition<T>(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) where T : Conditions.Operations.BinaryOperation, new()
        {
            return new T().Create(column.SqlText, parameter.SqlText);
        }

        public abstract string Build();
    }
}
