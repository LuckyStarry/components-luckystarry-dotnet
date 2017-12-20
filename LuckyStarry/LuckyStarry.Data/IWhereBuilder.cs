﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IWhereBuilder : ICompleteBuilder, IOrderBuildable
    {
        IWhereBuilder And(ISqlCondition condition);
        IWhereBuilder Or(ISqlCondition condition);
    }
}
