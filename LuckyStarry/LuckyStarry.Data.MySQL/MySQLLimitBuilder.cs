using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLLimitBuilder : MySQLBuilder, ICompleteBuilder
    {
        private readonly int offset;
        private readonly int rows;

        protected internal MySQLLimitBuilder(MySQLFromBuilder from, int rows) : this(from, 0, rows) { }
        protected internal MySQLLimitBuilder(MySQLWhereBuilderExtensible where, int rows) : this(where, 0, rows) { }
        protected internal MySQLLimitBuilder(MySQLOrderBuilder order, int rows) : this(order, 0, rows) { }

        protected internal MySQLLimitBuilder(MySQLFromBuilder from, int offset, int rows) : base(from)
        {
            this.offset = offset;
            this.rows = rows;
        }

        protected internal MySQLLimitBuilder(MySQLWhereBuilderExtensible where, int offset, int rows) : base(where)
        {
            this.offset = offset;
            this.rows = rows;
        }

        protected internal MySQLLimitBuilder(MySQLOrderBuilder order, int offset, int rows) : base(order)
        {
            this.offset = offset;
            this.rows = rows;
        }

        public string Build() => this.Compile();

        protected internal override string CompilePart() => this.offset > 0 ? $"LIMIT { this.offset }, { this.rows }" : $"LIMIT { this.rows }";
    }
}
