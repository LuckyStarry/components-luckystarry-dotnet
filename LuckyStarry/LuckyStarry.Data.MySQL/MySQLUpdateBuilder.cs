using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLUpdateBuilder : MySQLBuilder, IUpdateBuilder
    {
        protected internal override string CompilePart() => $@"UPDATE ";

        ITableBuilderUpdatable IUpdateBuilder.Table(string table) => this.Table(table);
        public virtual MySQLTableUpdateCommandBuilder Table(string table) => new MySQLTableUpdateCommandBuilder(this, table);
    }
}
