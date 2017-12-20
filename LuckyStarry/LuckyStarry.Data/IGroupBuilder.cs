using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IGroupBuilder
    {
        IHavingBuilder Have(string column, string value);
    }
}
