using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereOrBuilder : MySQLWhereBuilder
    {
        private readonly ICondition condition;

        protected internal MySQLWhereOrBuilder(MySQLCommandFactory factory, MySQLWhereBuilder where, ICondition condition) : base(factory, where, condition) => this.condition = condition;

        protected internal override string Compile() => $"{ this.Previous.Compile() } OR { this.CompilePart() }";
    }
}
