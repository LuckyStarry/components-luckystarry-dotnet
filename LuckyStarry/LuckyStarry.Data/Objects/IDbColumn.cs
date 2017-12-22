using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.Objects
{
    public interface IDbColumn : IDbObject, ISqlTextElement
    {
        string Alias { get; }
        string SqlTextAlias { get; }
    }
}
