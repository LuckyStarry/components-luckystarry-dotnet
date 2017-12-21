using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IUpdateBuilder
    {
        IUpdateTableBuilder Table(string table);
    }
}
