using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLOrderBuilder : MySQLBuilder, IOrderBuilder
    {
        private readonly string column;
        private readonly OrderType order;

        public MySQLOrderBuilder(MySQLWhereBuilder where, string column) : this(where, column, OrderType.ASC) { }
        public MySQLOrderBuilder(MySQLWhereBuilder where, string column, OrderType order) : base(where)
        {
            this.column = column;
            this.order = order;
        }

        public MySQLOrderBuilder(MySQLOrderBuilder orderby, string column) : this(orderby, column, OrderType.ASC) { }
        public MySQLOrderBuilder(MySQLOrderBuilder orderby, string column, OrderType order) : base(orderby)
        {
            this.column = column;
            this.order = order;
        }

        protected internal override string CompilePart()
        {
            return this.Previous is IOrderBuilder
                ? $"{ this.Previous.Compile() }, `{ this.column }` { this.order }"
                : $"ORDER BY `{ this.column }` { this.order }";
        }

        IOrderBuilder IOrderBuilder.ThenBy(string column) => this.ThenBy(column);
        IOrderBuilder IOrderBuilder.ThenByDescending(string column) => this.ThenByDescending(column);

        public MySQLOrderBuilder ThenBy(string column)
        {
            return new MySQLOrderBuilder(this, column);
        }

        public MySQLOrderBuilder ThenByDescending(string column)
        {
            return new MySQLOrderBuilder(this, column, OrderType.DESC);
        }

        public virtual string Build() => this.Compile();

        public enum OrderType
        {
            ASC, DESC
        }
    }
}
