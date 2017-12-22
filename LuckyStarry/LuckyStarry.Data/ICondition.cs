using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ICondition
    {
        ICondition And(ICondition condition);
        ICondition Or(ICondition condition);
        ICondition Not();

        string Build();
    }
}
