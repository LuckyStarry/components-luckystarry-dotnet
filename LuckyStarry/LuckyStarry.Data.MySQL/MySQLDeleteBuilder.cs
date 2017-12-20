using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLDeleteBuilder : MySQLCommandBuilder, IDeleteBuilder
    {
        protected internal override string CompilePart()
        {
            return $@"DELETE ";
        }
    }
}
