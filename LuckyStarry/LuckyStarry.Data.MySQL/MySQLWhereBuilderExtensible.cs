using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereBuilderExtensible : MySQLBuilder, IWhereBuilderExtensible
    {
        private ICondition condition;
        protected internal MySQLWhereBuilderExtensible(MySQLCommandFactory factory, MySQLFromBuilder from, ICondition condition) : base(factory, from) => this.condition = condition;
        protected internal MySQLWhereBuilderExtensible(MySQLCommandFactory factory, MySQLWhereBuilderExtensible where, ICondition condition) : base(factory, where) => this.condition = condition;

        public string Build() => this.Compile();

        IWhereBuilder IWhereBuilder.And(ICondition condition) => this.And(condition);
        IWhereBuilder IWhereBuilder.Or(ICondition condition) => this.Or(condition);
        IOrderBuilder IOrderBuildable.OrderBy(Data.Objects.IDbColumn column) => this.OrderBy(column);
        IOrderBuilder IOrderBuildable.OrderByDescending(Data.Objects.IDbColumn column) => this.OrderByDescending(column);

        protected internal override string CompilePart() => this.condition.Build();

        protected internal override string Compile() => $"{ this.Previous.Compile() } WHERE { this.CompilePart() }";

        public virtual MySQLWhereAndBuilderExtensible And(ICondition condition) => new MySQLWhereAndBuilderExtensible(this.factory, this, condition);
        public virtual MySQLWhereOrBuilderExtensible Or(ICondition condition) => new MySQLWhereOrBuilderExtensible(this.factory, this, condition);
        public virtual MySQLOrderBuilder OrderBy(Data.Objects.IDbColumn column) => new MySQLOrderASCBuilder(this.factory, this, column);
        public virtual MySQLOrderBuilder OrderByDescending(Data.Objects.IDbColumn column) => new MySQLOrderDESCBuilder(this.factory, this, column);
        public virtual MySQLLimitBuilder Limit(int rows) => new MySQLLimitBuilder(this.factory, this, rows);
        public virtual MySQLLimitBuilder Limit(int offset, int rows) => new MySQLLimitBuilder(this.factory, this, offset, rows);
    }
}
