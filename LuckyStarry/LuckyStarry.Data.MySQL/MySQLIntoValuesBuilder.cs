using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLIntoValuesBuilder : MySQLBuilder, IIntoValuesBuilder
    {
        private readonly string parameter;

        public MySQLIntoValuesBuilder(MySQLIntoColumnsBuilder table, string parameter) : base(table) => this.parameter = parameter;
        public MySQLIntoValuesBuilder(MySQLIntoValuesBuilder previous, string parameter) : base(previous) => this.parameter = parameter;

        protected internal override string CompilePart() => $"@{ this.parameter }";

        protected internal override string Compile()
        {
            return $"{ this.Previous.Compile() } { (this.Previous is IIntoValuesBuilder ? "," : ") VALUES (") } { this.CompilePart() }";
        }

        public virtual string Build() => $"{ this.Compile() })";

        IIntoValuesBuilder IIntoValuesBuilder.Value(string parameters) => this.Value(parameter);
        IIntoValuesBuilder IIntoValuesBuilder.Values(IEnumerable<string> parameters) => this.Values(parameters);
        public virtual MySQLIntoValuesBuilder Value(string paramter) => new MySQLIntoValuesBuilder(this, parameter);
        public virtual MySQLIntoValuesBuilder Values(IEnumerable<string> parameters)
        {
            var values = this.Value(parameters.First());
            var less = parameters.Skip(1);
            return less != null && less.Any() ? values : values.Values(less);
        }
    }
}
