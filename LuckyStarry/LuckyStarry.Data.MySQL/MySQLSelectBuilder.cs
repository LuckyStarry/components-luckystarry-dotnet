using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLSelectBuilder : MySQLBuilder, ISelectBuilder
    {
        IFromBuilder ISelectBuilder.From(string table) => this.From(table);
        IFromBuilder ISelectBuilder.FromAs(string table, string alias) => this.FromAs(table, alias);

        ISelectBuilder ISelectBuilder.Column(string column) => this.Column(column);
        ISelectBuilder ISelectBuilder.ColumnAs(string column, string alias) => this.ColumnAs(column, alias);
        ISelectBuilder ISelectBuilder.Columns(IEnumerable<string> columns) => this.Columns(columns);

        public virtual MySQLFromBuilder From(string table) => new MySQLFromBuilder(this, table);
        public virtual MySQLFromBuilder FromAs(string table, string alias) => new MySQLFromBuilder(this, table, alias);

        private Dictionary<string, string> columns { get; } = new Dictionary<string, string>();

        public virtual MySQLSelectBuilder Column(string column) => this.ColumnAs(column, column);
        public virtual MySQLSelectBuilder ColumnAs(string column, string alias)
        {
            this.columns[alias] = column;
            return this;
        }

        public virtual MySQLSelectBuilder Columns(IEnumerable<string> columns)
        {
            foreach (var column in columns)
            {
                this.Column(column);
            }
            return this;
        }

        protected internal override string CompilePart()
        {
            return $@"SELECT { string.Join(",", this.columns.Select(kv => $"`{ kv.Value }` AS `{ kv.Key }`")) }";
        }
    }
}
