﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface ITableBuilder
    {
        IWhereBuilder Where(ISqlCondition condition);
    }
}
