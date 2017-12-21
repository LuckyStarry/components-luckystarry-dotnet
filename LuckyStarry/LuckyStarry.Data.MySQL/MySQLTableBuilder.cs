using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLTableBuilder : MySQLBuilder, ITableBuilder
    {
        private readonly string table;

        public MySQLTableBuilder(MySQLSelectBuilder select, string table) : base(select) => this.table = table;
        public MySQLTableBuilder(MySQLUpdateBuilder update, string table) : base(update) => this.table = table;
        public MySQLTableBuilder(MySQLDeleteBuilder delete, string table) : base(delete) => this.table = table;

        protected internal override string CompilePart()
        {
            return $"`{ this.table }`";
        }

        public virtual string Build() => this.Compile();

        IWhereBuilder ITableBuilder.Where(ICondition condition) => this.Where(condition);
        public virtual MySQLWhereBuilder Where(ICondition condition) => new MySQLWhereBuilder(this, condition);
    }
}
