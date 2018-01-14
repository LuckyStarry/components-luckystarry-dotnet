using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public abstract class MySQLOrderBuilder : MySQLBuilder, IOrderBuilder
    {
        private readonly Data.Objects.IDbColumn column;
        public abstract string OrderType { get; }

        protected internal MySQLOrderBuilder(MySQLCommandFactory factory, MySQLWhereBuilderExtensible where, Data.Objects.IDbColumn column) : base(factory, where) => this.column = column;
        protected internal MySQLOrderBuilder(MySQLCommandFactory factory, MySQLOrderBuilder orderby, Data.Objects.IDbColumn column) : base(factory, orderby) => this.column = column;
        protected internal MySQLOrderBuilder(MySQLCommandFactory factory, MySQLFromBuilder orderby, Data.Objects.IDbColumn column) : base(factory, orderby) => this.column = column;

        protected internal override string CompilePart() => string.IsNullOrWhiteSpace(this.OrderType) ? this.column.SqlText : $"{ this.column.SqlText } { this.OrderType }";
        protected internal override string Compile()
        {
            var connect = this.Previous is IOrderBuilder ? "," : " ORDER BY";
            return $"{ this.Previous.Compile() }{ connect } { this.CompilePart() }";
        }

        IOrderBuilder IOrderBuilder.ThenBy(Data.Objects.IDbColumn column) => this.ThenBy(column);
        IOrderBuilder IOrderBuilder.ThenByDescending(Data.Objects.IDbColumn column) => this.ThenByDescending(column);

        public virtual MySQLOrderBuilder ThenBy(Data.Objects.IDbColumn column) => new MySQLOrderASCBuilder(this.factory, this, column);
        public virtual MySQLOrderBuilder ThenByDescending(Data.Objects.IDbColumn column) => new MySQLOrderDESCBuilder(this.factory, this, column);
        public virtual MySQLLimitBuilder Limit(int rows) => new MySQLLimitBuilder(this.factory, this, rows);
        public virtual MySQLLimitBuilder Limit(int offset, int rows) => new MySQLLimitBuilder(this.factory, this, offset, rows);

        public virtual string Build() => this.Compile();
    }
}
