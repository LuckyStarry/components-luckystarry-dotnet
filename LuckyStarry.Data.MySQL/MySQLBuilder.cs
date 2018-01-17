using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public abstract class MySQLBuilder
    {
        protected readonly MySQLCommandFactory factory;
        public MySQLBuilder(MySQLCommandFactory factory) : this(factory, null) { }
        public MySQLBuilder(MySQLCommandFactory factory, MySQLBuilder previous)
        {
            this.factory = factory;
            this.Previous = previous;
        }

        protected internal virtual MySQLBuilder Previous { get; }

        protected internal abstract string CompilePart();

        protected internal virtual string Compile()
        {
            return $"{ this.Previous?.Compile() } { this.CompilePart() }";
        }
    }
}
