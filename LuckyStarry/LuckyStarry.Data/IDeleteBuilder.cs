using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IDeleteBuilder
    {
        IFromBuilder From(string table);
    }
}
