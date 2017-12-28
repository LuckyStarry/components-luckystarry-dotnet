using System;
using System.Collections.Generic;
using System.Text;
using LuckyStarry.App.Utils.Logger.Models;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Aliyun.Api.LOG;
using Aliyun.Api.LOG.Data;
using System.Threading;
using Aliyun.Api.LOG.Request;
using System.Linq;

namespace LuckyStarry.App.Utils.Logger
{
    public class AliyunSLSLogger : IAppLogger, IDisposable
    {
        private readonly LogClient client;
        private readonly IAppInfo appInfo;
        private readonly string project;
        private readonly string logstore;
        private readonly object syncLock = new object();
        private BlockingCollection<LogItem> logContexts;

        public AliyunSLSLogger(IAppInfo appInfo, string project, string logstore, string endpoint, string accessKeyId, string accessKey)
        {
            this.RecreateList();
            this.appInfo = appInfo;
            this.project = project;
            this.logstore = logstore;
            this.client = new LogClient(endpoint, accessKeyId, accessKey);
            this.consumer = new Timer(state => this.Consume(), null, 0, 5 * 1000);
        }

        IAppLogContext IAppLogger.CreateLogContext() => this.CreateLogContext();
        public AliyunSLSLogContext CreateLogContext() => new AliyunSLSLogContext(this);

        public void Save(AliyunSLSLogContext logContext)
        {
            var logItem = logContext.ToLogItem();
            if (logItem != null)
            {
                logItem.PushBack("Environment", this.appInfo.GetEnviroment());
                this.logContexts.TryAdd(logItem);
            }
        }

        private BlockingCollection<LogItem> RecreateList()
        {
            lock (this.syncLock)
            {
                var logContexts = this.logContexts;
                this.logContexts = new BlockingCollection<LogItem>(100);
                return logContexts;
            }
        }

        private Timer consumer;
        private void Consume()
        {
            try
            {
                var logContexts = this.RecreateList();
                if (logContexts != null && logContexts.Count > 0)
                {
                    var putLogsRequest = new PutLogsRequest();
                    putLogsRequest.Project = this.project;
                    putLogsRequest.Topic = this.appInfo.GetAppName();
                    putLogsRequest.Logstore = this.logstore;
                    putLogsRequest.LogItems = logContexts.ToList();
                    this.client.PutLogs(putLogsRequest);
                }
            }
            finally { }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                this.consumer.Dispose();

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~AliyunSLSLogger() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        void IDisposable.Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
