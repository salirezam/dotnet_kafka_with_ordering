using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedEvents
{
    public class Event : IEvent
    {
        [JsonRequired]
        public Guid Id { get; set; }
        [JsonRequired]
        public DateTime TimeStamp { get; set; }

        public Event()
        {
            Id = Guid.NewGuid();
            TimeStamp = DateTime.UtcNow;
        }
    }
}
