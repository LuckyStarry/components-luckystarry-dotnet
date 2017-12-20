using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLSelectBuilder : MySQLCommandBuilder, ISelectBuilder
    {
        ISelectBuilder ISelectBuilder.Column(string column) => this.Column(column);
        ISelectBuilder ISelectBuilder.ColumnAs(string column, string alias) => this.ColumnAs(column, alias);
        ISelectBuilder ISelectBuilder.Columns(IEnumerable<string> columns) => this.Columns(columns);

        private Dictionary<string, string> columns { get; } = new Dictionary<string, string>();

        public virtual MySQLSelectBuilder Column(string column)
        {
            return this.ColumnAs(column, column);
        }

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
            return $@"
SELECT { string.Join(",", this.columns.Select(kv => $"`{ kv.Value }` AS `{ kv.Key }`")) }
  FROM ";
        }
    }
}
