using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLOrderASCBuilder : MySQLOrderBuilder
    {
        public MySQLOrderASCBuilder(MySQLCommandFactory factory, MySQLWhereBuilderExtensible where, Data.Objects.IDbColumn column) : base(factory, where, column) { }
        public MySQLOrderASCBuilder(MySQLCommandFactory factory, MySQLOrderBuilder orderby, Data.Objects.IDbColumn column) : base(factory, orderby, column) { }
        public MySQLOrderASCBuilder(MySQLCommandFactory factory, MySQLFromBuilder from, Data.Objects.IDbColumn column) : base(factory, from, column) { }

        public override string OrderType => string.Empty;
    }
}
