using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.App.Utils.Logger.Models
{
    public interface IAppLogContext
    {
        string Message { set; get; }
        string Module { set; get; }
        string Catelog { set; get; }
        LogLevel Level { set; get; }

        string this[string key] { set; get; }

        void Save();
    }
}
