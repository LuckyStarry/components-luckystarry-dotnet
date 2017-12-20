using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLTableBuilder : MySQLBuilder, ITableBuilder
    {
        private readonly string table;
        private readonly string alias;

        public MySQLTableBuilder(MySQLCommandBuilder command, string table) : this(command, table, string.Empty) { }
        public MySQLTableBuilder(MySQLCommandBuilder command, string table, string alias) : base(command)
        {
            this.table = table;
            this.alias = alias;
        }

        IWhereBuilder ITableBuilder.Where(ISqlCondition condition) => this.Where(condition);

        public virtual MySQLWhereBuilder Where(ISqlCondition condition)
        {
            return new MySQLWhereBuilder(this, condition);
        }

        protected internal override string CompilePart()
        {
            return string.IsNullOrWhiteSpace(this.alias)
                ? $"`{ this.table }`"
                : $"`{ this.table }` AS `{ this.alias }`";
        }
    }
}
