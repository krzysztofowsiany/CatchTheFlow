using System.Collections.Generic;
using System.Linq;
using LiteDB;
using EventBus.Extensions;

namespace EventBus
{
    public class LiteDBEventRepository : IEventRepository
    {
        public void Add(Event @event)
        {
            using(var db = new LiteDatabase(@"event_store.db"))
            {
                var col = db.GetCollection<Event>("events");
                col.Insert(@event);
            }
        }

        public IEnumerable<TEvent> GetEvents<TEvent>(string typeName) 
            where TEvent : class
        {
            using(var db = new LiteDatabase(@"event_store.db"))
            {
                var col = db.GetCollection<Event>("events");
                return col.FindAll()
                    .Where(e => e.Type == typeName)
                    .OrderByDescending(e=> e.Timestamp)
                    .Select(e => e.Data.Deserialize<TEvent>())
                    .ToList();
            }
        }

        public IEnumerable<string> GetNamesOfEvents()
        {
            using(var db = new LiteDatabase(@"event_store.db"))
            {
                var col = db.GetCollection<Event>("events");
                return col.FindAll()
                        .OrderByDescending(e=> e.Timestamp)
                        .Select(e => e.Type)
                        .ToList();
            }
        }
    }
}