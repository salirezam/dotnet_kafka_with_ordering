using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using SharedEvents;

namespace KafkaProducer.Handlers
{
    public class MessageReceivedEventHandler : IEventHandler<MessageReceivedEvent, string>
    {
        public MessageReceivedEvent HandleAsync(string @event)
        {
            return new MessageReceivedEvent
            {
                Message = @event
            };
        }
    }
}
