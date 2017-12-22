using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereBuilderExtensible : MySQLWhereBuilder, IWhereBuilderExtensible
    {
        protected internal MySQLWhereBuilderExtensible(MySQLFromBuilder from, ICondition condition) : base(from, condition) { }

        IOrderBuilder IOrderBuildable.OrderBy(Data.Objects.IDbColumn column) => this.OrderBy(column);
        IOrderBuilder IOrderBuildable.OrderByDescending(Data.Objects.IDbColumn column) => this.OrderByDescending(column);

        public virtual MySQLOrderBuilder OrderBy(Data.Objects.IDbColumn column) => new MySQLOrderASCBuilder(this, column);
        public virtual MySQLOrderBuilder OrderByDescending(Data.Objects.IDbColumn column) => new MySQLOrderDESCBuilder(this, column);
    }
}
