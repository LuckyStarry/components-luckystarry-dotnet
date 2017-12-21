using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLIntoColumnsBuilder : MySQLBuilder, IIntoColumnsBuilder
    {
        private readonly string column;

        public MySQLIntoColumnsBuilder(MySQLIntoBuilder table, string column) : base(table) => this.column = column;
        public MySQLIntoColumnsBuilder(MySQLIntoColumnsBuilder previous, string column) : base(previous) => this.column = column;

        protected internal override string CompilePart() => $"`{ this.column }`";

        protected internal override string Compile()
        {
            return $"{ this.Previous.Compile() } { (this.Previous is IIntoColumnsBuilder ? "," : "(") } { this.CompilePart() }";
        }

        IIntoValuesBuilder IIntoColumnsBuilder.Value(string parameter) => this.Value(parameter);
        IIntoValuesBuilder IIntoColumnsBuilder.Values(IEnumerable<string> parameters) => this.Values(parameters);
        IIntoColumnsBuilder IIntoBuilder.Column(string column) => this.Column(column);
        IIntoColumnsBuilder IIntoBuilder.Columns(IEnumerable<string> columns) => this.Columns(columns);

        public virtual MySQLIntoColumnsBuilder Column(string column) => new MySQLIntoColumnsBuilder(this, column);
        public virtual MySQLIntoColumnsBuilder Columns(IEnumerable<string> columns)
        {
            var c = this.Column(columns.First());
            var less = columns.Skip(1);
            return less != null && less.Any() ? c : c.Columns(less);
        }
        public virtual MySQLIntoValuesBuilder Value(string parameter) => new MySQLIntoValuesBuilder(this, column);
        public virtual MySQLIntoValuesBuilder Values(IEnumerable<string> parameters)
        {
            var values = this.Value(parameters.First());
            var less = parameters.Skip(1);
            return less != null && less.Any() ? values : values.Values(less);
        }
    }
}
