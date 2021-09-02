using Newtonsoft.Json;

namespace SharedEvents
{
    public class MessageReceivedEvent : Event
    {
        [JsonRequired]
        public string Message { get; set; }
    }
}
