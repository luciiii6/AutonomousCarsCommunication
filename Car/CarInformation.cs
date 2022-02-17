using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousCarsCommunication
{
    //It doesn't need setters because once created this attributes can't change in a car
    class CarInformation
    {
        private int id;
        private string manufacturer;
        private string model;
        private int currentSpeed;
        private Location location;
        private List<Event> events;

        public CarInformation(int id, string manufacturer, string model, Location location)
        {
            this.id = id;
            this.manufacturer = manufacturer;
            this.model = model;
            this.location = location;
            this.events = new List<Event>();
        }

        public CarInformation(CarInformation info)
        {
            this.id = info.id;
            this.manufacturer = info.manufacturer;
            this.model = info.model;
            this.location = info.location;
            this.events = new List<Event>();
        }
        // first 3 don't need setters because once the car is created they can't be changed
        public int Id { get { return id; } }
        public string Manufacturer { get { return manufacturer; } }
        public string Model { get { return model; } }
        public int CurrentSpeed { get { return currentSpeed; } set { currentSpeed = value; } }
        public Location Location { get { return location; } set { location = value; } }
        public List<Event> Events { get { return events; } set { events = value; } }
    }
}
