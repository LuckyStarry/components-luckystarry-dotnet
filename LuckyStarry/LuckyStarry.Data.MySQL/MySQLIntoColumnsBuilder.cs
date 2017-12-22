using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLIntoColumnsBuilder : MySQLBuilder, IIntoColumnsBuilder
    {
        private readonly Data.Objects.IDbColumn column;

        protected internal MySQLIntoColumnsBuilder(MySQLIntoBuilder table, Data.Objects.IDbColumn column) : base(table) => this.column = column;
        protected internal MySQLIntoColumnsBuilder(MySQLIntoColumnsBuilder previous, Data.Objects.IDbColumn column) : base(previous) => this.column = column;

        protected internal override string CompilePart() => this.column.SqlText;

        protected internal override string Compile()
        {
            return $"{ this.Previous.Compile() } { (this.Previous is MySQLIntoColumnsBuilder ? "," : "(") } { this.CompilePart() }";
        }

        IIntoValuesBuilder IIntoColumnsBuilder.Value(Data.Objects.IDbParameter parameter) => this.Value(parameter);
        IIntoValuesBuilder IIntoColumnsBuilder.Values(IEnumerable<Data.Objects.IDbParameter> parameters) => this.Values(parameters);
        IIntoColumnsBuilder IIntoBuilder.Column(Data.Objects.IDbColumn column) => this.Column(column);
        IIntoColumnsBuilder IIntoBuilder.Columns(IEnumerable<Data.Objects.IDbColumn> columns) => this.Columns(columns);

        public virtual MySQLIntoColumnsBuilder Column(Data.Objects.IDbColumn column) => new MySQLIntoColumnsBuilder(this, column);
        public virtual MySQLIntoColumnsBuilder Columns(IEnumerable<Data.Objects.IDbColumn> columns)
        {
            var c = this.Column(columns.First());
            var less = columns.Skip(1);
            return less != null && less.Any() ? c : c.Columns(less);
        }
        public virtual MySQLIntoValuesBuilder Value(Data.Objects.IDbParameter parameter) => new MySQLIntoValuesBuilder(this, parameter);
        public virtual MySQLIntoValuesBuilder Values(IEnumerable<Data.Objects.IDbParameter> parameters)
        {
            var values = this.Value(parameters.First());
            var less = parameters.Skip(1);
            return less != null && less.Any() ? values : values.Values(less);
        }
    }
}
