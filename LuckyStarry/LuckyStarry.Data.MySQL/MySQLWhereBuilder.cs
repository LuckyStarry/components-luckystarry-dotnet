using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereBuilder : MySQLBuilder, IWhereBuilder
    {
        private ICondition condition;

        protected internal MySQLWhereBuilder(MySQLTableBuilder table, ICondition condition) : base(table) => this.condition = condition;
        protected internal MySQLWhereBuilder(MySQLWhereBuilder where, ICondition condition) : base(where) => this.condition = condition;

        public string Build() => this.Compile();

        IWhereBuilder IWhereBuilder.And(ICondition condition) => this.And(condition);
        IWhereBuilder IWhereBuilder.Or(ICondition condition) => this.Or(condition);

        protected internal override string CompilePart() => this.condition.Build();

        protected internal override string Compile() => $"{ this.Previous.Compile() } WHERE { this.CompilePart() }";

        public virtual MySQLWhereAndBuilder And(ICondition condition) => new MySQLWhereAndBuilder(this, condition);
        public virtual MySQLWhereOrBuilder Or(ICondition condition) => new MySQLWhereOrBuilder(this, condition);
    }
}
