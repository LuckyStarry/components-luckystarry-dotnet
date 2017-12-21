using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLInsertBuilder : MySQLBuilder, IInsertBuilder
    {
        protected internal override string CompilePart() => $@"INSERT ";

        IIntoBuilder IInsertBuilder.Into(string table)
        {
            throw new NotImplementedException();
        }
    }
}
