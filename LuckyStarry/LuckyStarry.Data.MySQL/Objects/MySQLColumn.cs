using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Objects
{
    public class MySQLColumn : Data.Objects.DbColumn
    {
        public MySQLColumn(string name) : base(name)
        {
        }

        public MySQLColumn(string name, string alias) : base(name, alias)
        {
        }

        public override string SqlText => $"`{ this.Name }`";

        public override string SqlTextAlias => $"`{ this.Alias }`";
    }
}
