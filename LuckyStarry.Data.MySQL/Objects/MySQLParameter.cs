using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Objects
{
    public class MySQLParameter : Data.Objects.DbParameter
    {
        public MySQLParameter(string name) : base(name)
        {
        }

        public override string SqlText => $"@{ this.Name }";
    }
}
