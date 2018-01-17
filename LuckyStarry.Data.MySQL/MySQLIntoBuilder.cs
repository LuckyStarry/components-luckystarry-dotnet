using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLIntoBuilder : MySQLBuilder, IIntoBuilder
    {
        private readonly MySQLInsertBuilder insert;
        private readonly Data.Objects.IDbTable table;

        protected internal MySQLIntoBuilder(MySQLCommandFactory factory, MySQLInsertBuilder insert, Data.Objects.IDbTable table) : base(factory, insert)
        {
            this.insert = insert;
            this.table = table;
        }

        protected MySQLIntoBuilder(MySQLCommandFactory factory, MySQLIntoBuilder setted) : base(factory, setted) { }

        protected internal override string CompilePart() => this.table.SqlText;
        protected internal override string Compile() => $"{ this.Previous.Compile() } INTO { this.CompilePart() }";

        IIntoColumnsBuilder IIntoBuilder.Column(Data.Objects.IDbColumn column) => this.Column(column);
        IIntoColumnsBuilder IIntoBuilder.Columns(IEnumerable<Data.Objects.IDbColumn> columns) => this.Columns(columns);

        public virtual MySQLIntoColumnsBuilder Column(Data.Objects.IDbColumn column) => new MySQLIntoColumnsBuilder(this.factory, this, column);
        public virtual MySQLIntoColumnsBuilder Columns(IEnumerable<Data.Objects.IDbColumn> columns)
        {
            var setted = this.Column(columns.First());
            var less = columns.Skip(1);
            return less == null ? setted : setted.Columns(less);
        }
    }
}
