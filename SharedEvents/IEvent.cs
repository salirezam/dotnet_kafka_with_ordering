using System;

namespace SharedEvents
{
    public interface IEvent
    {
        public Guid Id { get; init; }
        public DateTime TimeStamp { get; init; }
    }
}
