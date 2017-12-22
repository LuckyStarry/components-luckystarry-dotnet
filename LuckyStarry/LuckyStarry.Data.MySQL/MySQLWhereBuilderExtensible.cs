using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereBuilderExtensible : MySQLWhereBuilder, IWhereBuilderExtensible
    {
        protected internal MySQLWhereBuilderExtensible(MySQLFromBuilder from, ICondition condition) : base(from, condition) { }

        IOrderBuilder IOrderBuildable.Order(Data.Objects.IDbColumn column) => this.Order(column);
        IOrderBuilder IOrderBuildable.OrderByDescending(Data.Objects.IDbColumn column) => this.OrderByDescending(column);

        public virtual MySQLOrderBuilder Order(Data.Objects.IDbColumn column) => new MySQLOrderBuilder(this, column);
        public virtual MySQLOrderBuilder OrderByDescending(Data.Objects.IDbColumn column) => new MySQLOrderBuilder(this, column, MySQLOrderBuilder.OrderType.DESC);
    }
}
