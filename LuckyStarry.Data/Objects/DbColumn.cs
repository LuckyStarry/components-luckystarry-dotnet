using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.Objects
{
    public abstract class DbColumn : DbObject, IDbColumn
    {
        public DbColumn(string name) : this(name, string.Empty) { }
        public DbColumn(string name, string alias) : base(name)
        {
            this.Alias = alias;
        }

        public abstract string SqlText { get; }

        public virtual string Alias { get; }

        public abstract string SqlTextAlias { get; }
    }
}
