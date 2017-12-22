using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereBuilderExtensible : MySQLBuilder, IWhereBuilderExtensible
    {
        private ICondition condition;
        protected internal MySQLWhereBuilderExtensible(MySQLFromBuilder from, ICondition condition) : base(from) => this.condition = condition;
        protected internal MySQLWhereBuilderExtensible(MySQLWhereBuilderExtensible where, ICondition condition) : base(where) => this.condition = condition;

        public string Build() => this.Compile();

        IWhereBuilder IWhereBuilder.And(ICondition condition) => this.And(condition);
        IWhereBuilder IWhereBuilder.Or(ICondition condition) => this.Or(condition);
        IOrderBuilder IOrderBuildable.OrderBy(Data.Objects.IDbColumn column) => this.OrderBy(column);
        IOrderBuilder IOrderBuildable.OrderByDescending(Data.Objects.IDbColumn column) => this.OrderByDescending(column);

        protected internal override string CompilePart() => this.condition.Build();

        protected internal override string Compile() => $"{ this.Previous.Compile() } WHERE { this.CompilePart() }";

        public virtual MySQLWhereAndBuilderExtensible And(ICondition condition) => new MySQLWhereAndBuilderExtensible(this, condition);
        public virtual MySQLWhereOrBuilderExtensible Or(ICondition condition) => new MySQLWhereOrBuilderExtensible(this, condition);
        public virtual MySQLOrderBuilder OrderBy(Data.Objects.IDbColumn column) => new MySQLOrderASCBuilder(this, column);
        public virtual MySQLOrderBuilder OrderByDescending(Data.Objects.IDbColumn column) => new MySQLOrderDESCBuilder(this, column);
        public virtual MySQLLimitBuilder Limit(int rows) => new MySQLLimitBuilder(this, rows);
        public virtual MySQLLimitBuilder Limit(int offset, int rows) => new MySQLLimitBuilder(this, offset, rows);
    }
}
