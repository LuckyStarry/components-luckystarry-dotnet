using LuckyStarry.App.Utils.Logger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.App.Utils.Logger
{
    public static class IAppLogContextUtils
    {
        public static T WithMessage<T>(this T logContext, string message) where T : IAppLogContext
        {
            logContext.Message = message;
            return logContext;
        }

        public static T WithModule<T>(this T logContext, string module) where T : IAppLogContext
        {
            logContext.Module = module;
            return logContext;
        }

        public static T WithCatelog<T>(this T logContext, string catelog) where T : IAppLogContext
        {
            logContext.Catelog = catelog;
            return logContext;
        }

        public static T WithLevel<T>(this T logContext, LogLevel level) where T : IAppLogContext
        {
            logContext.Level = level;
            return logContext;
        }
    }
}
