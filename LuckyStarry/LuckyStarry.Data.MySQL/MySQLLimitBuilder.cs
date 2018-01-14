using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLLimitBuilder : MySQLBuilder, ICompleteBuilder
    {
        private readonly int offset;
        private readonly int rows;

        protected internal MySQLLimitBuilder(MySQLCommandFactory factory, MySQLFromBuilder from, int rows) : this(factory, from, 0, rows) { }
        protected internal MySQLLimitBuilder(MySQLCommandFactory factory, MySQLWhereBuilderExtensible where, int rows) : this(factory, where, 0, rows) { }
        protected internal MySQLLimitBuilder(MySQLCommandFactory factory, MySQLOrderBuilder order, int rows) : this(factory, order, 0, rows) { }

        protected internal MySQLLimitBuilder(MySQLCommandFactory factory, MySQLFromBuilder from, int offset, int rows) : base(factory, from)
        {
            this.offset = offset;
            this.rows = rows;
        }

        protected internal MySQLLimitBuilder(MySQLCommandFactory factory, MySQLWhereBuilderExtensible where, int offset, int rows) : base(factory, where)
        {
            this.offset = offset;
            this.rows = rows;
        }

        protected internal MySQLLimitBuilder(MySQLCommandFactory factory, MySQLOrderBuilder order, int offset, int rows) : base(factory, order)
        {
            this.offset = offset;
            this.rows = rows;
        }

        public string Build() => this.Compile();

        protected internal override string CompilePart() => this.offset > 0 ? $"LIMIT { this.offset }, { this.rows }" : $"LIMIT { this.rows }";
    }
}
