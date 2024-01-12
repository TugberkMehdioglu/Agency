using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.COMMON.Extensions
{
    public static class SessionExtension
    {
        public static void SetSession<T>(this ISession session, string key, T value) where T : class
        {
            string serializedValue = JsonSerializer.Serialize(value);
            session.SetString(key, serializedValue);
        }

        public static T? GetSession<T>(this ISession session, string key) where T : class
        {
            string? serializedValue = session.GetString(key);
            if (string.IsNullOrEmpty(serializedValue)) return null;

            try
            {
                return JsonSerializer.Deserialize<T>(serializedValue);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
