using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.Objects
{
    public abstract class DbTable : DbObject, IDbTable
    {
        public DbTable(string name) : this(name, string.Empty) { }
        public DbTable(string name, string alias) : base(name)
        {
            this.Alias = alias;
        }

        public abstract string SqlText { get; }

        public virtual string Alias { get; }

        public abstract string SqlTextAlias { get; }
    }
}
