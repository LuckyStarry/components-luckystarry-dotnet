using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.Objects
{
    public class DbObject : IDbObject
    {
        public DbObject(string name)
        {
            this.Name = name;
        }

        public virtual string Name { get; }
    }
}
