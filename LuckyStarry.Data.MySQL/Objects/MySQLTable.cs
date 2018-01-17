using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Objects
{
    public class MySQLTable : Data.Objects.DbTable
    {
        public MySQLTable(string name) : base(name)
        {
        }

        public MySQLTable(string name, string alias) : base(name, alias)
        {
        }

        public override string SqlText => $"`{ this.Name }`";

        public override string SqlTextAlias => $"`{ this.Alias }`";
    }
}
