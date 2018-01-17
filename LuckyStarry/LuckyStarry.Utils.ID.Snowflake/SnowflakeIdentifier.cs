using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Utils.ID.Snowflake
{
    public sealed class SnowflakeIdentifier : Identifier
    {
        public SnowflakeIdentifier() { }
        public SnowflakeIdentifier(long value) => this.Value = value;
        public string Version => "SNOWFLAKE";
        public long Value { get; }
    }
}
