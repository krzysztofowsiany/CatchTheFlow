using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace EventBus.Extensions
{
    public static class BSONExtensions
    {
        public static TEvent Deserialize<TEvent>(this string data) where TEvent: class
        {
            var dataArray = Convert.FromBase64String(data);
            TEvent @event;
            
            var ms = new MemoryStream(dataArray);
            using (var reader = new BsonReader(ms))
            {
                var serializer = new JsonSerializer();
               @event = serializer.Deserialize<TEvent>(reader);
            }

            return @event;
        }
        
        public static string Serialize<TEvent>(this TEvent @event) where TEvent: class
        {
            var ms = new MemoryStream();
            using (var writer = new BsonWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, @event);
            }

            return Convert.ToBase64String(ms.ToArray());
        }
    }
}