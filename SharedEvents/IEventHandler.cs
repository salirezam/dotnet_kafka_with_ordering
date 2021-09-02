using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEvents
{
    public interface IEventHandler<T, U> where T : IEvent
    {
        T HandleAsync(U @event);
    }
}
