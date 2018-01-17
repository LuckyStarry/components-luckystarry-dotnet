using Aliyun.Api.LOG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.App.Utils.Logger.Models
{
    public sealed class AliyunSLSLogContext : IAppLogContext
    {
        internal AliyunSLSLogContext(AliyunSLSLogger logger)
        {
            this.logger = logger;
        }

        public string Message { set; get; }
        public string Module { set; get; }
        public string Catelog { set; get; }
        public LogLevel Level { set; get; } = LogLevel.Info;

        private IDictionary<string, string> items = new Dictionary<string, string>();
        public string this[string key]
        {
            set => this.items[key] = value;
            get => this.items[key];
        }

        public void Save()
        {
            this.logger.Save(this);
        }

        public LogItem ToLogItem()
        {
            if (string.IsNullOrWhiteSpace(this.Message))
            {
                return null;
            }
            var logItem = new LogItem { };
            logItem.Time = TimeSpan();
            logItem.PushBack(nameof(this.Message), this.Message);
            logItem.PushBack(nameof(this.Level), this.Level.ToString());
            if (!string.IsNullOrWhiteSpace(this.Module))
            {
                logItem.PushBack(nameof(this.Module), this.Module);
            }
            if (!string.IsNullOrWhiteSpace(this.Catelog))
            {
                logItem.PushBack(nameof(this.Catelog), this.Catelog);
            }
            if (this.items != null && this.items.Any())
            {
                foreach (var kv in this.items.OrderBy(kv => kv.Key))
                {
                    logItem.PushBack($"custom.{ kv.Key }", kv.Value ?? string.Empty);
                }
            }
            return logItem;
        }

        private static DateTime _1970StartDateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
        private readonly AliyunSLSLogger logger;

        public static uint TimeSpan() => (uint)Math.Round((DateTime.Now - _1970StartDateTime).TotalSeconds, MidpointRounding.AwayFromZero);
    }
}
