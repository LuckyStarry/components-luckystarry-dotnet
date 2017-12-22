using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    class MySQLOrderDESCBuilder : MySQLOrderBuilder
    {
        public MySQLOrderDESCBuilder(MySQLWhereBuilder where, Data.Objects.IDbColumn column) : base(where, column) { }
        public MySQLOrderDESCBuilder(MySQLOrderBuilder orderby, Data.Objects.IDbColumn column) : base(orderby, column) { }
        public MySQLOrderDESCBuilder(MySQLFromBuilder from, Data.Objects.IDbColumn column) : base(from, column) { }

        public override string OrderType => "DESC";
    }
}
