using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStarry.Data
{
    public interface IDbClientFactory
    {
        IDbClient Create(string dbName);
        Task<IDbClient> CreateAsync(string dbName);
    }
}
