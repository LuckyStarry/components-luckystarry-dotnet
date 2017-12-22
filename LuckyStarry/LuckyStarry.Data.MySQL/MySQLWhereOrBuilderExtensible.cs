using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereOrBuilderExtensible : MySQLWhereBuilderExtensible
    {
        private readonly ICondition condition;

        protected internal MySQLWhereOrBuilderExtensible(MySQLWhereBuilderExtensible where, ICondition condition) : base(where, condition) => this.condition = condition;

        protected internal override string Compile() => $"{ this.Previous.Compile() } OR { this.CompilePart() }";
    }
}
