using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEvents
{
    public class MessageReceivedEvent : Event
    {
        public string Message { get; set; }
    }
}
