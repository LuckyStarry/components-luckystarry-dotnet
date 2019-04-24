using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public enum ResponseType
    {
        SUCCESS = 0,
        ERROR_PARAMETERS = 1,
        ERROR_FAILED = 3,
        ERROR_EXCEPTION = 7,
        ERROR_REQUEST = 8,
        ERROR_AUTH = 9
    }
}
