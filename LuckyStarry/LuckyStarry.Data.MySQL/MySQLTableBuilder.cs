using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLTableBuilder : MySQLBuilder, ITableBuilder
    {
        private readonly Data.Objects.IDbTable table;

        protected internal MySQLTableBuilder(MySQLCommandFactory factory, MySQLSelectBuilder select, Data.Objects.IDbTable table) : base(factory, select) => this.table = table;
        protected internal MySQLTableBuilder(MySQLCommandFactory factory, MySQLUpdateBuilder update, Data.Objects.IDbTable table) : base(factory, update) => this.table = table;
        protected internal MySQLTableBuilder(MySQLCommandFactory factory, MySQLDeleteBuilder delete, Data.Objects.IDbTable table) : base(factory, delete) => this.table = table;
        internal MySQLTableBuilder(MySQLCommandFactory factory, MySQLTableUpdateCommandBuilder setted) : base(factory, setted) { }

        protected internal override string CompilePart() => this.table.SqlText;

        protected internal override string Compile() => $"{ this.Previous.Compile() } { this.CompilePart() }";

        public virtual string Build() => this.Compile();

        IWhereBuilder ITableBuilder.Where(ICondition condition) => this.Where(condition);
        public virtual MySQLWhereBuilder Where(ICondition condition) => new MySQLWhereBuilder(this.factory, this, condition);
    }
}
