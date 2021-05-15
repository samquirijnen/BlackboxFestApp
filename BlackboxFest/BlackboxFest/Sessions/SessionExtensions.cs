using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlackboxFest.Sessions
{
    public static class SessionExtensions
    {
        //public static void Set<T>(this ISession session, string key, T value)
        //{
        //    session.SetString(key, JsonSerializer.Serialize(value));
        //}
        //public static T Get<T>(this ISession session, string key)
        //{
        //    var value = session.GetString(key);
        //    return value == null ? default : JsonSerializer.Deserialize<T>(value);

        //}
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }

    }
}
