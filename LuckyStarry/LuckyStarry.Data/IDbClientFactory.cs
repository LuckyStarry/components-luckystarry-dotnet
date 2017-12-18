using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IDbClientFactory
    {
        IDbClient Create(string dbName);
    }
}
