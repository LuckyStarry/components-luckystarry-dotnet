using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLUpdateBuilder : MySQLBuilder, IUpdateBuilder
    {
        protected internal MySQLUpdateBuilder() { }
        protected internal override string CompilePart() => "UPDATE";
        protected internal override string Compile() => this.CompilePart();

        ITableBuilderUpdatable IUpdateBuilder.Table(Data.Objects.IDbTable table) => this.Table(table);
        public virtual MySQLTableUpdateCommandBuilder Table(Data.Objects.IDbTable table) => new MySQLTableUpdateCommandBuilder(this, table);
    }
}
