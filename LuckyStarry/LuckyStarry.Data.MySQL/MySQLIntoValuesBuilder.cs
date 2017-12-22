using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLIntoValuesBuilder : MySQLBuilder, IIntoValuesBuilder
    {
        private readonly Data.Objects.IDbParameter parameter;

        protected internal MySQLIntoValuesBuilder(MySQLIntoColumnsBuilder table, Data.Objects.IDbParameter parameter) : base(table) => this.parameter = parameter;
        protected internal MySQLIntoValuesBuilder(MySQLIntoValuesBuilder previous, Data.Objects.IDbParameter parameter) : base(previous) => this.parameter = parameter;

        protected internal override string CompilePart() => this.parameter.SqlText;

        protected internal override string Compile()
        {
            return $"{ this.Previous.Compile() }{ (this.Previous is MySQLIntoValuesBuilder ? "," : " ) VALUES (") } { this.CompilePart() }";
        }

        public virtual string Build() => $"{ this.Compile() } )";

        IIntoValuesBuilder IIntoValuesBuilder.Value(Data.Objects.IDbParameter parameters) => this.Value(parameter);
        IIntoValuesBuilder IIntoValuesBuilder.Values(IEnumerable<Data.Objects.IDbParameter> parameters) => this.Values(parameters);
        public virtual MySQLIntoValuesBuilder Value(Data.Objects.IDbParameter parameter) => new MySQLIntoValuesBuilder(this, parameter);
        public virtual MySQLIntoValuesBuilder Values(IEnumerable<Data.Objects.IDbParameter> parameters)
        {
            var values = this.Value(parameters.First());
            var less = parameters.Skip(1);
            return less != null && less.Any() ? values.Values(less) : values;
        }
    }
}
