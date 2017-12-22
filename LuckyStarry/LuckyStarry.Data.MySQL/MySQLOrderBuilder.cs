using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLOrderBuilder : MySQLBuilder, IOrderBuilder
    {
        private readonly Data.Objects.IDbColumn column;
        private readonly OrderType order;

        protected internal MySQLOrderBuilder(MySQLWhereBuilder where, Data.Objects.IDbColumn column) : this(where, column, OrderType.ASC) { }
        protected internal MySQLOrderBuilder(MySQLWhereBuilder where, Data.Objects.IDbColumn column, OrderType order) : base(where)
        {
            this.column = column;
            this.order = order;
        }

        protected internal MySQLOrderBuilder(MySQLOrderBuilder orderby, Data.Objects.IDbColumn column) : this(orderby, column, OrderType.ASC) { }
        protected internal MySQLOrderBuilder(MySQLOrderBuilder orderby, Data.Objects.IDbColumn column, OrderType order) : base(orderby)
        {
            this.column = column;
            this.order = order;
        }

        protected internal override string CompilePart()
        {
            return $"{ this.column.SqlText } { this.order }";
        }

        protected internal override string Compile()
        {
            var connect = this.Previous is IOrderBuilder ? "," : "ORDER BY";
            return $"{ this.Previous.Compile() } { connect } { this.CompilePart() }";
        }

        IOrderBuilder IOrderBuilder.ThenBy(Data.Objects.IDbColumn column) => this.ThenBy(column);
        IOrderBuilder IOrderBuilder.ThenByDescending(Data.Objects.IDbColumn column) => this.ThenByDescending(column);

        public MySQLOrderBuilder ThenBy(Data.Objects.IDbColumn column) => new MySQLOrderBuilder(this, column);
        public MySQLOrderBuilder ThenByDescending(Data.Objects.IDbColumn column) => new MySQLOrderBuilder(this, column, OrderType.DESC);

        public virtual string Build() => this.Compile();

        public enum OrderType
        {
            ASC, DESC
        }
    }
}
