using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLDeleteBuilder : MySQLBuilder, IDeleteBuilder
    {
        protected internal MySQLDeleteBuilder() { }
        protected internal override string CompilePart() => $"DELETE";
        protected internal override string Compile() => this.CompilePart();

        ITableBuilder IDeleteBuilder.From(Data.Objects.IDbTable table) => this.From(table);
        public virtual MySQLTableBuilder From(Data.Objects.IDbTable table) => new MySQLTableBuilder(this, table);
    }
}
