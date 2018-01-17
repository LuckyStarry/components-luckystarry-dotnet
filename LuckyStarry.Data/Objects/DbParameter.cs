using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.Objects
{
    public abstract class DbParameter : DbObject, IDbParameter
    {
        public DbParameter(string name) : base(name)
        {
        }

        public abstract string SqlText { get; }
    }
}
