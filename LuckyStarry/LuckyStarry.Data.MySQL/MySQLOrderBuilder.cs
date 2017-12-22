using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public abstract class MySQLOrderBuilder : MySQLBuilder, IOrderBuilder
    {
        private readonly Data.Objects.IDbColumn column;
        public abstract string OrderType { get; }

        protected internal MySQLOrderBuilder(MySQLWhereBuilder where, Data.Objects.IDbColumn column) : base(where) => this.column = column;
        protected internal MySQLOrderBuilder(MySQLOrderBuilder orderby, Data.Objects.IDbColumn column) : base(orderby) => this.column = column;
        protected internal MySQLOrderBuilder(MySQLFromBuilder orderby, Data.Objects.IDbColumn column) : base(orderby) => this.column = column;

        protected internal override string CompilePart() => string.IsNullOrWhiteSpace(this.OrderType) ? this.column.SqlText : $"{ this.column.SqlText } { this.OrderType }";
        protected internal override string Compile()
        {
            var connect = this.Previous is IOrderBuilder ? "," : " ORDER BY";
            return $"{ this.Previous.Compile() }{ connect } { this.CompilePart() }";
        }

        IOrderBuilder IOrderBuilder.ThenBy(Data.Objects.IDbColumn column) => this.ThenBy(column);
        IOrderBuilder IOrderBuilder.ThenByDescending(Data.Objects.IDbColumn column) => this.ThenByDescending(column);

        public virtual MySQLOrderBuilder ThenBy(Data.Objects.IDbColumn column) => new MySQLOrderASCBuilder(this, column);
        public virtual MySQLOrderBuilder ThenByDescending(Data.Objects.IDbColumn column) => new MySQLOrderDESCBuilder(this, column);

        public virtual string Build() => this.Compile();
    }
}
