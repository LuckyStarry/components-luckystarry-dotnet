using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IDbObjectFactory
    {
        Objects.IDbColumn CreateColumn(string name);
        Objects.IDbParameter CreateParameter(string name);
        Objects.IDbTable CreateTable(string name);
    }
}
