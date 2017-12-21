using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLFromBuilder : MySQLTableBuilder, IFromBuilder
    {
        private readonly string table;
        private readonly string alias;

        public MySQLFromBuilder(MySQLSelectBuilder select, string table) : this(select, table, string.Empty) { }
        public MySQLFromBuilder(MySQLSelectBuilder select, string table, string alias) : base(select, table)
        {
            this.table = table;
            this.alias = alias;
        }

        IWhereBuilder ITableBuilder.Where(ICondition condition) => this.Where(condition);
        IWhereBuilderExtensible IFromBuilder.Where(ICondition condition) => this.Where(condition);

        public new virtual MySQLWhereBuilderExtensible Where(ICondition condition) => new MySQLWhereBuilderExtensible(this, condition);

        protected internal override string CompilePart()
        {
            return string.IsNullOrWhiteSpace(this.alias)
                ? $"FROM `{ this.table }`"
                : $"FROM `{ this.table }` AS `{ this.alias }`";
        }

        public override string Build() => this.Compile();
    }
}
