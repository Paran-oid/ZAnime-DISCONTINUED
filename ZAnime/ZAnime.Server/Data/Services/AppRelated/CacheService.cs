using StackExchange.Redis;
using System.Text.Json;
using Zanime.Server.Data.Services.Interfaces.AppRelated;

namespace Zanime.Server.Data.Services.AppRelated
{
    public class CacheService : ICacheService
    {
        private IDatabase _cacheDb;

        public CacheService()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _cacheDb = redis.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = _cacheDb.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var date = expirationTime.DateTime.Subtract(DateTime.Now);

            bool res = _cacheDb.StringSet(key, JsonSerializer.Serialize(value), date);

            return res;
        }

        public object RemoveData(string key)
        {
            var exists = _cacheDb.KeyExists(key);
            if (exists)
            {
                _cacheDb.KeyDelete(key);
            }
            return false;
        }
    }
}