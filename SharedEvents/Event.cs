using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEvents
{
    public class Event : IEvent
    {
        public Guid Id { get; init; }
        public DateTime TimeStamp { get; init; }

        public Event()
        {
            Id = Guid.NewGuid();
            TimeStamp = DateTime.UtcNow;
        }
    }
}
