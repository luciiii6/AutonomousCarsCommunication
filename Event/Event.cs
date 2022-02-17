using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousCarsCommunication
{
    class Event
    {
        private int kilometer;
        private EventType type;

        public Event(EventType type,int kilometer)
        {
            this.type = type;
            this.kilometer = kilometer;
        }
        
        // These do not need setters because you don't want to change an event after it is set
        public EventType Type { get { return type; } }
        public int Kilometer { get { return kilometer; } }

    }
}
