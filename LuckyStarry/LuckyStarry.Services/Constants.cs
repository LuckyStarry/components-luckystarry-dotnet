using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Services
{
    class Constants
    {
        public static readonly string[] DEFAULT_COLUMNS = typeof(Models.IEntity).GetProperties().Select(p => p.Name).ToArray();
    }
}
