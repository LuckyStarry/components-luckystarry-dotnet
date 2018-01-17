using System;

namespace LuckyStarry.App.Utils
{
    public interface IAppInfo
    {
        string GetAppName();
        string GetEnviroment();
        bool IsDevelopment();
    }
}
