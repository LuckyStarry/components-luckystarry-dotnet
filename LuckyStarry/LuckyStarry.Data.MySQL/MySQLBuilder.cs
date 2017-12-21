using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public abstract class MySQLBuilder
    {
        public MySQLBuilder() : this(null) { }
        public MySQLBuilder(MySQLBuilder previous)
        {
            this.Previous = previous;
        }

        protected internal virtual MySQLBuilder Previous { get; }

        protected internal abstract string CompilePart();

        protected internal virtual string Compile()
        {
            return $"{ this.Previous?.CompilePart() } { this.CompilePart() }";
        }
    }
}
