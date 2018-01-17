using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    class MySQLOrderDESCBuilder : MySQLOrderBuilder
    {
        public MySQLOrderDESCBuilder(MySQLCommandFactory factory, MySQLWhereBuilderExtensible where, Data.Objects.IDbColumn column) : base(factory, where, column) { }
        public MySQLOrderDESCBuilder(MySQLCommandFactory factory, MySQLOrderBuilder orderby, Data.Objects.IDbColumn column) : base(factory, orderby, column) { }
        public MySQLOrderDESCBuilder(MySQLCommandFactory factory, MySQLFromBuilder from, Data.Objects.IDbColumn column) : base(factory, from, column) { }

        public override string OrderType => "DESC";
    }
}
