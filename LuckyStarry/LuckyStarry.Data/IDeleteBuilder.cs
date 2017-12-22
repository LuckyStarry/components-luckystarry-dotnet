using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IDeleteBuilder
    {
        ITableBuilder From(Objects.IDbTable table);
    }
}
