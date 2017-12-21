using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.Objects
{
    public abstract class DbTable : DbObject, IDbTable
    {
        public DbTable(string name) : base(name)
        {
        }

        public abstract string SqlText { get; }
    }
}
