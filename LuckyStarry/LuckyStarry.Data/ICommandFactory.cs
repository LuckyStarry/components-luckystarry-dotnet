using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ICommandFactory
    {
        ISelectBuilder CreateSelectBuilder();
        IInsertBuilder CreateInsertBuilder();
        IUpdateBuilder CreateUpdateBuilder();
        IDeleteBuilder CreateDeleteBuilder();

        IConditionFactory GetConditionFactory();
        IDbObjectFactory GetDbObjectFactory();
    }
}
