using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Utils.ID.Snowflake
{
    public class SnowflakeIdentifierGetFailedException : Exception
    {
        const string DEFAULT_MESSAGE = "获取雪花标识失败";
        public SnowflakeIdentifierGetFailedException(string api) : this(api, DEFAULT_MESSAGE) { }
        public SnowflakeIdentifierGetFailedException(string api, Exception innerException) : this(api, DEFAULT_MESSAGE, innerException) { }
        public SnowflakeIdentifierGetFailedException(string api, string message) : this(api, message, null) { }
        public SnowflakeIdentifierGetFailedException(string api, string message, Exception innerException) : base(message, innerException) => this.Api = api;

        public string Api { get; }
    }
}
