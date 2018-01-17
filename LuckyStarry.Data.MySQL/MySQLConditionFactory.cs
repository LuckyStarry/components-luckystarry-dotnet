using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLConditionFactory : IConditionFactory
    {
        private readonly MySQLCommandFactory commandFactory;
        protected internal MySQLConditionFactory(MySQLCommandFactory commandFactory) => this.commandFactory = commandFactory;

        ICondition IConditionFactory.EqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.EqualTo(column, parameter);
        ICondition IConditionFactory.GreaterThan(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.GreaterThan(column, parameter);
        ICondition IConditionFactory.GreaterThanOrEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.GreaterThanOrEqualTo(column, parameter);
        ICondition IConditionFactory.LessThan(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.LessThan(column, parameter);
        ICondition IConditionFactory.LessThanOrEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.LessThanOrEqualTo(column, parameter);
        ICondition IConditionFactory.NotEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => this.NotEqualTo(column, parameter);
        ICondition IConditionFactory.IsNull(Data.Objects.IDbColumn column) => this.IsNull(column);
        ICondition IConditionFactory.NotIsNull(Data.Objects.IDbColumn column) => this.NotIsNull(column);

        public virtual MySQLCondition EqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.EQ(column, parameter);
        public virtual MySQLCondition GreaterThan(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.GT(column, parameter);
        public virtual MySQLCondition GreaterThanOrEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.GTE(column, parameter);
        public virtual MySQLCondition LessThan(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.LT(column, parameter);
        public virtual MySQLCondition LessThanOrEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.LTE(column, parameter);
        public virtual MySQLCondition NotEqualTo(Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) => MySQLCondition.NE(column, parameter);
        public virtual MySQLCondition IsNull(Data.Objects.IDbColumn column) => MySQLCondition.NULL(column);
        public virtual MySQLCondition NotIsNull(Data.Objects.IDbColumn column) => MySQLCondition.NOTNULL(column);

        public virtual MySQLCondition EqualTo(Func<MySQLDbObjectFactory, Objects.MySQLColumn> columnFunc, Func<MySQLDbObjectFactory, Objects.MySQLParameter> parameterFunc)
        {
            var dbObjectFactory = this.commandFactory.GetDbObjectFactory();
            var column = columnFunc(dbObjectFactory);
            var parameter = parameterFunc(dbObjectFactory);
            return this.EqualTo(column, parameter);
        }

        public virtual MySQLCondition GreaterThan(Func<MySQLDbObjectFactory, Objects.MySQLColumn> columnFunc, Func<MySQLDbObjectFactory, Objects.MySQLParameter> parameterFunc)
        {
            var dbObjectFactory = this.commandFactory.GetDbObjectFactory();
            var column = columnFunc(dbObjectFactory);
            var parameter = parameterFunc(dbObjectFactory);
            return this.GreaterThan(column, parameter);
        }

        public virtual MySQLCondition GreaterThanOrEqualTo(Func<MySQLDbObjectFactory, Objects.MySQLColumn> columnFunc, Func<MySQLDbObjectFactory, Objects.MySQLParameter> parameterFunc)
        {
            var dbObjectFactory = this.commandFactory.GetDbObjectFactory();
            var column = columnFunc(dbObjectFactory);
            var parameter = parameterFunc(dbObjectFactory);
            return this.GreaterThanOrEqualTo(column, parameter);
        }

        public virtual MySQLCondition LessThan(Func<MySQLDbObjectFactory, Objects.MySQLColumn> columnFunc, Func<MySQLDbObjectFactory, Objects.MySQLParameter> parameterFunc)
        {
            var dbObjectFactory = this.commandFactory.GetDbObjectFactory();
            var column = columnFunc(dbObjectFactory);
            var parameter = parameterFunc(dbObjectFactory);
            return this.LessThan(column, parameter);
        }

        public virtual MySQLCondition LessThanOrEqualTo(Func<MySQLDbObjectFactory, Objects.MySQLColumn> columnFunc, Func<MySQLDbObjectFactory, Objects.MySQLParameter> parameterFunc)
        {
            var dbObjectFactory = this.commandFactory.GetDbObjectFactory();
            var column = columnFunc(dbObjectFactory);
            var parameter = parameterFunc(dbObjectFactory);
            return this.LessThanOrEqualTo(column, parameter);
        }

        public virtual MySQLCondition NotEqualTo(Func<MySQLDbObjectFactory, Objects.MySQLColumn> columnFunc, Func<MySQLDbObjectFactory, Objects.MySQLParameter> parameterFunc)
        {
            var dbObjectFactory = this.commandFactory.GetDbObjectFactory();
            var column = columnFunc(dbObjectFactory);
            var parameter = parameterFunc(dbObjectFactory);
            return this.NotEqualTo(column, parameter);
        }

        public virtual MySQLCondition IsNull(Func<MySQLDbObjectFactory, Objects.MySQLColumn> columnFunc)
        {
            var dbObjectFactory = this.commandFactory.GetDbObjectFactory();
            var column = columnFunc(dbObjectFactory);
            return this.IsNull(column);
        }

        public virtual MySQLCondition NotIsNull(Func<MySQLDbObjectFactory, Objects.MySQLColumn> columnFunc)
        {
            var dbObjectFactory = this.commandFactory.GetDbObjectFactory();
            var column = columnFunc(dbObjectFactory);
            return this.NotIsNull(column);
        }
    }
}
