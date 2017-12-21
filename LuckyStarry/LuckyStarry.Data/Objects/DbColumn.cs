using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.Objects
{
    public abstract class DbColumn : DbObject, IDbColumn
    {
        public DbColumn(string name) : base(name)
        {
        }

        public abstract string SqlText { get; }
    }
}
