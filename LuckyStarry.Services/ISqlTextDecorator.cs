using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Services
{
    public interface ISqlTextDecorator
    {
        string Comment(string sql, string func);
        string ColumnName(string name);
        string TableName(string name);
        string ParameterName(string name);
    }
}
