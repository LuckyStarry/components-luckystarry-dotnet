using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.App.Utils.Logger
{
    public interface IAppLogger
    {
        Models.IAppLogContext CreateLogContext();
    }
}
