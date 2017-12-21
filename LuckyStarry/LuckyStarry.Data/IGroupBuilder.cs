using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IGroupBuilder : ICompleteBuilder
    {
        IHavingBuilder Have(string column, string value);
    }
}
