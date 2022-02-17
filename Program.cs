using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousCarsCommunication
{
    class Program
    {
        //Scenarios
        static void Main(string[] args)
        {
            Car car1 = new Car(new CarInformation(102, "Mercedes", "A200", new Location(239, 321)));
            car1.SetCurrentSpeed(45);

            Car car2 = new Car(new CarInformation(23, "Hyundai", "i20", new Location(123, 600)));
            car2.SetCurrentSpeed(90);

            Car car3 = new Car(new CarInformation(123, "Dacia", "Logan", new Location(237, 333)));

            List<Car> cars = new List<Car> { car2, car3 };

            Car nearestToCar1 = car1.GetNearestCar(cars);

            Console.WriteLine(nearestToCar1.CarInformation.Manufacturer + " " +  nearestToCar1.CarInformation.Model);
            Console.WriteLine();

            Event event0 = new Event(EventType.Speeding, 2323);
            Event event1 = new Event(EventType.Speeding, 2522);
            Event event2 = new Event(EventType.Speeding, 2526);
            car1.AddEvent(event0);
            car1.AddEvent(event1);
            car1.AddEvent(event2);

            //Only the last 2 events will be visible
            Console.WriteLine("Events " + car1.CarInformation.Manufacturer +" "+ car1.CarInformation.Model +":");
            foreach(Event ev in car1.CarInformation.Events)
            {
                Console.WriteLine(ev.Type + " " + ev.Kilometer);
            }

            Console.WriteLine();



            car1.ReceiveInformationFromMultipleCars(cars);

            Console.WriteLine("Info received from other cars: ");
            foreach(CarInformation info in car1.InfoOtherCars)
            {
                Console.WriteLine(info.Manufacturer + " " + info.Model);
            }
        }
    }
}
