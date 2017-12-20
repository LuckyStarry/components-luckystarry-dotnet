using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLInsertBuilder : MySQLCommandBuilder, IInsertBuilder
    {
        protected internal override string CompilePart()
        {
            return $@"INSERT ";
        }
    }
}
