using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereAndBuilder : MySQLWhereBuilder
    {
        private readonly ICondition condition;

        protected internal MySQLWhereAndBuilder(MySQLWhereBuilder where, ICondition condition) : base(where, condition) => this.condition = condition;

        protected internal override string Compile() => $"{ this.Previous.Compile() } AND { this.CompilePart() }";
    }
}
