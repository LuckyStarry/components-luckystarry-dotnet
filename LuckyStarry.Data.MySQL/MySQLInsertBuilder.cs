using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLInsertBuilder : MySQLBuilder, IInsertBuilder
    {
        protected internal MySQLInsertBuilder(MySQLCommandFactory factory) : base(factory) { }
        protected internal override string CompilePart() => "INSERT";
        protected internal override string Compile() => this.CompilePart();

        IIntoBuilder IInsertBuilder.Into(Data.Objects.IDbTable table) => this.Into(table);
        public virtual MySQLIntoBuilder Into(Data.Objects.IDbTable table) => new MySQLIntoBuilder(this.factory, this, table);
    }
}
