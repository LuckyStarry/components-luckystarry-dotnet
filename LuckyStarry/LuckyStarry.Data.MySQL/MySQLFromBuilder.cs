using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLFromBuilder : MySQLTableBuilder, IFromBuilder
    {
        private readonly Data.Objects.IDbTable table;

        protected internal MySQLFromBuilder(MySQLSelectBuilder select, Data.Objects.IDbTable table) : base(select, table) => this.table = table;

        IWhereBuilder ITableBuilder.Where(ICondition condition) => this.Where(condition);
        IWhereBuilderExtensible IFromBuilder.Where(ICondition condition) => this.Where(condition);

        public new virtual MySQLWhereBuilderExtensible Where(ICondition condition) => new MySQLWhereBuilderExtensible(this, condition);

        protected internal override string CompilePart()
        {
            return string.IsNullOrWhiteSpace(this.table.Alias)
                ? $"{ this.table.SqlText }"
                : $"{ this.table.SqlText } AS { this.table.SqlTextAlias }";
        }

        protected internal override string Compile()
        {
            if (this.Previous is ISelectBuilderColumnsSelected)
            {
                return $"{ this.Previous.Compile() } FROM { this.CompilePart() }";
            }
            else
            {
                return $"{ this.Previous.Compile() } * FROM { this.CompilePart() }";
            }
        }

        public override string Build() => this.Compile();
    }
}
