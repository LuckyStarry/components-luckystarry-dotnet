using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LuckyStarry.Utils.ID.Snowflake
{
    public sealed class SnowflakeApiIdentifierUtils : IIdentifierUtils
    {
        private readonly HttpClient client;
        private readonly string apiPath;

        public SnowflakeApiIdentifierUtils(string apiPath)
        {
            this.client = new HttpClient();
            this.apiPath = apiPath;
        }

        Identifier IIdentifierUtils.New() => this.New();
        public SnowflakeIdentifier New() => this.NewAsync().Result;
        public async Task<SnowflakeIdentifier> NewAsync()
        {
            try
            {
                var response = await this.client.GetStringAsync(this.apiPath);
                if (response != null && !string.IsNullOrWhiteSpace(response))
                {
                    var value = 0L;
                    if (long.TryParse(response, out value) && value > 0)
                    {
                        return new SnowflakeIdentifier(value);
                    }
                }
            }
            catch (Exception exception)
            {
                throw new SnowflakeIdentifierGetFailedException(this.apiPath, exception);
            }
            throw new SnowflakeIdentifierGetFailedException(this.apiPath);
        }
    }
}
