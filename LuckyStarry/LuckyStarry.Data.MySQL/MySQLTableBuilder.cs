using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLTableBuilder : MySQLBuilder, ITableBuilder
    {
        private readonly Data.Objects.IDbTable table;

        protected internal MySQLTableBuilder(MySQLSelectBuilder select, Data.Objects.IDbTable table) : base(select) => this.table = table;
        protected internal MySQLTableBuilder(MySQLUpdateBuilder update, Data.Objects.IDbTable table) : base(update) => this.table = table;
        protected internal MySQLTableBuilder(MySQLDeleteBuilder delete, Data.Objects.IDbTable table) : base(delete) => this.table = table;

        protected internal override string CompilePart() => this.table.SqlText;

        protected internal override string Compile() => $"{ this.Previous.Compile() } { this.CompilePart() }";

        public virtual string Build() => this.Compile();

        IWhereBuilder ITableBuilder.Where(ICondition condition) => this.Where(condition);
        public virtual MySQLWhereBuilder Where(ICondition condition) => new MySQLWhereBuilder(this, condition);
    }
}
