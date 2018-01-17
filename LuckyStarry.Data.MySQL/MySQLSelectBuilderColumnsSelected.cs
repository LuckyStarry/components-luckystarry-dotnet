using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLSelectBuilderColumnsSelected : MySQLSelectBuilder, ISelectBuilderColumnsSelected
    {
        private readonly Data.Objects.IDbColumn column;

        protected internal MySQLSelectBuilderColumnsSelected(MySQLCommandFactory factory, MySQLSelectBuilder select, Data.Objects.IDbColumn column) : base(factory, select) => this.column = column;

        protected internal override string CompilePart() => string.IsNullOrWhiteSpace(this.column.Alias) ? this.column.SqlText : $"{ this.column.SqlText } AS { this.column.SqlTextAlias }";

        protected internal override string Compile()
        {
            var connect = this.Previous is MySQLSelectBuilderColumnsSelected ? "," : string.Empty;
            return $"{ this.Previous.Compile() }{ connect } { this.CompilePart() }";
        }
    }
}
