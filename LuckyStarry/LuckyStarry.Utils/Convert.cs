using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Utils
{
    public static partial class Convert
    {
        private readonly static string[] BASE62 = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        public static string ToBase62(this long numeric)
        {
            if (numeric < 0)
            {
                return $"-{ ToBase62(numeric * -1) }";
            }
            var less = numeric / 62;
            var mod = numeric % 62;
            if (less > 0)
            {
                return $"{ ToBase62(less) }{ BASE62[mod] }";
            }
            else
            {
                return BASE62[mod];
            }
        }

        public static string ToBase62(this ulong numeric)
        {
            var less = numeric / 62;
            var mod = numeric % 62;
            if (less > 0)
            {
                return $"{ ToBase62(less) }{ BASE62[mod] }";
            }
            else
            {
                return BASE62[mod];
            }
        }
    }
}
