using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStarry.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create(string name);
        Task<IDbConnection> CreateAsync(string name);
    }
}
