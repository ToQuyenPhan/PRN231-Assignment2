using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ProjectParticipantManagementSystemWebClient.Utils
{
    public static class SessionUtil
    {
        public static void setAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T getFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return string.IsNullOrEmpty(value) ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
