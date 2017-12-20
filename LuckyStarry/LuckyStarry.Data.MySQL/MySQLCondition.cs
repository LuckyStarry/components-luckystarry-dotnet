﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public abstract class MySQLCondition : ISqlCondition
    {
        private Conditions.ComposeCondition next;

        ISqlCondition ISqlCondition.And(ISqlCondition condition) => this.And(condition);
        ISqlCondition ISqlCondition.Or(ISqlCondition condition) => this.Or(condition);

        public virtual MySQLCondition And(ISqlCondition condition)
        {
            this.next = new Conditions.AndCondition(condition);
            return this.next;
        }

        public virtual MySQLCondition Or(ISqlCondition condition)
        {
            this.next = new Conditions.OrCondition(condition);
            return this;
        }

        public virtual string Build()
        {
            return this.next?.Build();
        }

        public static MySQLCondition EQ(string column, string parameter) => BinaryCondition<Conditions.Operations.Equal>(column, parameter);
        public static MySQLCondition NE(string column, string parameter) => BinaryCondition<Conditions.Operations.NotEqual>(column, parameter);
        public static MySQLCondition LT(string column, string parameter) => BinaryCondition<Conditions.Operations.LessThan>(column, parameter);
        public static MySQLCondition LTE(string column, string parameter) => BinaryCondition<Conditions.Operations.LessThanOrEqual>(column, parameter);
        public static MySQLCondition GT(string column, string parameter) => BinaryCondition<Conditions.Operations.GreaterThan>(column, parameter);
        public static MySQLCondition GTE(string column, string parameter) => BinaryCondition<Conditions.Operations.GreaterThanOrEqual>(column, parameter);


        private static MySQLCondition BinaryCondition<T>(string column, string parameter) where T : Conditions.Operations.BinaryOperation, new()
        {
            return new T().Create($"`{ column }`", $"@{ parameter }");
        }
    }
}
