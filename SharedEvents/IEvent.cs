using System;

namespace SharedEvents
{
    public interface IEvent
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
