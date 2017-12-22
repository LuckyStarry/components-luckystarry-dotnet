using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLOrderASCBuilder : MySQLOrderBuilder
    {
        public MySQLOrderASCBuilder(MySQLWhereBuilder where, Data.Objects.IDbColumn column) : base(where, column) { }
        public MySQLOrderASCBuilder(MySQLOrderBuilder orderby, Data.Objects.IDbColumn column) : base(orderby, column) { }
        public MySQLOrderASCBuilder(MySQLFromBuilder from, Data.Objects.IDbColumn column) : base(from, column) { }

        public override string OrderType => string.Empty;
    }
}
