using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create(string name);
    }
}
