using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLWhereBuilderExtensible : MySQLWhereBuilder, IWhereBuilderExtensible
    {
        public MySQLWhereBuilderExtensible(MySQLFromBuilder from, ICondition condition) : base(from, condition) { }

        IOrderBuilder IOrderBuildable.Order(string column) => this.Order(column);
        IOrderBuilder IOrderBuildable.OrderByDescending(string column) => this.OrderByDescending(column);

        public virtual MySQLOrderBuilder Order(string column)
        {
            return new MySQLOrderBuilder(this, column);
        }

        public virtual MySQLOrderBuilder OrderByDescending(string column)
        {
            return new MySQLOrderBuilder(this, column, MySQLOrderBuilder.OrderType.DESC);
        }
    }
}
