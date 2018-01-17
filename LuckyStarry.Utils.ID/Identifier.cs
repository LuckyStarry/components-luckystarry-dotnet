using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Utils.ID
{
    public interface Identifier
    {
        string Version { get; }

        long Value { get; }
    }
}
