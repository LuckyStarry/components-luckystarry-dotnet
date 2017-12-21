using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLIntoBuilder : MySQLBuilder, IIntoBuilder
    {
        private readonly MySQLInsertBuilder insert;
        private readonly string table;
        private readonly MySQLIntoBuilder setted;

        public MySQLIntoBuilder(MySQLInsertBuilder insert, string table) : base(insert)
        {
            this.insert = insert;
            this.table = table;
        }

        public MySQLIntoBuilder(MySQLIntoBuilder setted) : this(setted.insert, setted.table) => this.setted = setted;

        protected internal override string CompilePart() => $"`{ this.table }`";

        IIntoColumnsBuilder IIntoBuilder.Column(string column) => this.Column(column);
        IIntoColumnsBuilder IIntoBuilder.Columns(IEnumerable<string> columns) => this.Columns(columns);

        public virtual MySQLIntoColumnsBuilder Column(string column) => new MySQLIntoColumnsBuilder(this, column);
        public virtual MySQLIntoColumnsBuilder Columns(IEnumerable<string> columns)
        {
            var setted = this.Column(columns.First());
            var less = columns.Skip(1);
            return less == null ? setted : setted.Columns(less);
        }
    }
}
