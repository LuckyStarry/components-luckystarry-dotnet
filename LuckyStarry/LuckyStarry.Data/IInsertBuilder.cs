﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data
{
    public interface IInsertBuilder
    {
        IIntoBuilder Into(string table);
    }
}
