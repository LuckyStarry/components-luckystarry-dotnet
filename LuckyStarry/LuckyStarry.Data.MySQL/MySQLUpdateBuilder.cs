using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLUpdateBuilder : MySQLCommandBuilder, IUpdateBuilder
    {
        protected internal override string CompilePart()
        {
            return $@"UPDATE ";
        }
    }
}
