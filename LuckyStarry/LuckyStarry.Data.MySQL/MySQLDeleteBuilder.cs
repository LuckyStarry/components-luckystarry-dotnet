using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLDeleteBuilder : MySQLBuilder, IDeleteBuilder
    {
        protected internal override string CompilePart() => $@"DELETE ";

        ITableBuilder IDeleteBuilder.From(string table) => this.From(table);
        public virtual MySQLTableBuilder From(string table) => new MySQLTableBuilder(this, table);
    }
}
