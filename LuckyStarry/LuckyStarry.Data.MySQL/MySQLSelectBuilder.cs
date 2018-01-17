using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLSelectBuilder : MySQLBuilder, ISelectBuilder
    {
        protected internal MySQLSelectBuilder(MySQLCommandFactory factory) : base(factory) { }
        protected internal MySQLSelectBuilder(MySQLCommandFactory factory, MySQLSelectBuilder selected) : base(factory, selected) { }

        IFromBuilder ISelectBuilder.From(Data.Objects.IDbTable table) => this.From(table);
        ISelectBuilderColumnsSelected ISelectBuilder.Column(Data.Objects.IDbColumn column) => this.Column(column);
        ISelectBuilderColumnsSelected ISelectBuilder.Columns(IEnumerable<Data.Objects.IDbColumn> columns) => this.Columns(columns);

        public virtual MySQLFromBuilder From(Data.Objects.IDbTable table) => new MySQLFromBuilder(this.factory, this, table);
        public virtual MySQLSelectBuilderColumnsSelected Column(Data.Objects.IDbColumn column) => new MySQLSelectBuilderColumnsSelected(this.factory, this, column);
        public virtual MySQLSelectBuilderColumnsSelected Columns(IEnumerable<Data.Objects.IDbColumn> columns)
        {
            var column = this.Column(columns.First());
            var less = columns.Skip(1);
            return less != null && less.Any() ? column.Columns(less) : column;
        }

        protected internal override string CompilePart() => "SELECT";
        protected internal override string Compile() => this.CompilePart();
    }
}
