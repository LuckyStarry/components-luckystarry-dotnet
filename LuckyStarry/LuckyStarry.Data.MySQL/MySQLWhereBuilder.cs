using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereBuilder : MySQLBuilder, IWhereBuilder
    {
        private ISqlCondition condition;

        public MySQLWhereBuilder(MySQLTableBuilder table, ISqlCondition condition) : base(table)
        {
            this.condition = condition;
        }

        public string Build() => this.Compile();

        IOrderBuilder IOrderBuildable.Order(string column) => this.Order(column);
        IOrderBuilder IOrderBuildable.OrderByDescending(string column) => this.OrderByDescending(column);

        IWhereBuilder IWhereBuilder.And(ISqlCondition condition) => this.And(condition);
        IWhereBuilder IWhereBuilder.Or(ISqlCondition condition) => this.Or(condition);

        protected internal override string CompilePart()
        {
            return $"WHERE { this.condition.Build() }";
        }

        public virtual MySQLOrderBuilder Order(string column)
        {
            return new MySQLOrderBuilder(this, column);
        }

        public virtual MySQLOrderBuilder OrderByDescending(string column)
        {
            return new MySQLOrderBuilder(this, column, MySQLOrderBuilder.OrderType.DESC);
        }

        public virtual MySQLWhereBuilder And(ISqlCondition condition)
        {
            this.condition = this.condition.And(condition);
            return this;
        }

        public virtual MySQLWhereBuilder Or(ISqlCondition condition)
        {
            this.condition = this.condition.Or(condition);
            return this;
        }
    }
}
