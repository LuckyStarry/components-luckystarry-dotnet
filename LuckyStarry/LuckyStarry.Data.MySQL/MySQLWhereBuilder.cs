﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereBuilder : MySQLBuilder, IWhereBuilder
    {
        private ICondition condition;

        protected internal MySQLWhereBuilder(MySQLTableBuilder table, ICondition condition) : base(table)
        {
            this.condition = condition;
        }

        public string Build() => this.Compile();

        IWhereBuilder IWhereBuilder.And(ICondition condition) => this.And(condition);
        IWhereBuilder IWhereBuilder.Or(ICondition condition) => this.Or(condition);

        protected internal override string CompilePart() => this.condition.Build();

        protected internal override string Compile()
        {
            return $"{ this.Previous.Compile() } WHERE { this.CompilePart() }";
        }

        public virtual MySQLWhereBuilder And(ICondition condition)
        {
            this.condition = this.condition.And(condition);
            return this;
        }

        public virtual MySQLWhereBuilder Or(ICondition condition)
        {
            this.condition = this.condition.Or(condition);
            return this;
        }
    }
}
