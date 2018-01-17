using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL.Tests
{
    class Utils
    {
        private static int n = new Random().Next();
        public static string RandomName()
        {
            n = new Random(n).Next();
            return LuckyStarry.Utils.Convert.ToBase62(n);
        }
    }
}
