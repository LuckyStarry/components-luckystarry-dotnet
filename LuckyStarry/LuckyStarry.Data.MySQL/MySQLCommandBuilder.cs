using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public abstract class MySQLCommandBuilder : MySQLBuilder, ICommandBuilder
    {
        public MySQLCommandBuilder() : base(null) { }

        ITableBuilder ICommandBuilder.From(string table) => this.From(table);
        ITableBuilder ICommandBuilder.FromAs(string table, string alias) => this.FromAs(table, alias);

        public virtual MySQLTableBuilder From(string table)
        {
            return new MySQLTableBuilder(this, table);
        }

        public virtual MySQLTableBuilder FromAs(string table, string alias)
        {
            return new MySQLTableBuilder(this, table, alias);
        }
    }
}
