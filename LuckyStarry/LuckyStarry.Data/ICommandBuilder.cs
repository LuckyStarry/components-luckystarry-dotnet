using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ICommandBuilder
    {
        ITableBuilder From(string table);
        ITableBuilder FromAs(string table, string alias);
    }
}
