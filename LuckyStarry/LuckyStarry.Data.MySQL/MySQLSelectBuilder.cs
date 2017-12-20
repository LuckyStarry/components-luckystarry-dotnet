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

        protected Dictionary<string, string> Columns { get; } = new Dictionary<string, string>();

        public virtual MySQLSelectBuilder Column(string column)
        {
            return this.ColumnAs(column, column);
        }

        public virtual MySQLSelectBuilder ColumnAs(string column, string alias)
        {
            this.Columns[alias] = column;
            return this;
        }

        protected internal override string CompilePart()
        {
            return $@"
SELECT { string.Join(",", this.Columns.Select(kv => $"`{ kv.Value }` AS `{ kv.Key }`")) }
  FROM ";
        }
    }
}
