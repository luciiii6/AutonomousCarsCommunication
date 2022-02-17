using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousCarsCommunication
{
    class Car
    {
        private CarInformation carInformation;
        private List<CarInformation> infoOtherCars;
        

        public Car(CarInformation info)
        {
            this.carInformation = info;
            this.infoOtherCars = new List<CarInformation>();
        }

        public CarInformation CarInformation { get { return carInformation; } }
        public List<CarInformation> InfoOtherCars { get { return infoOtherCars; } }

        public void SetCurrentSpeed(int speed)
        {
            if(speed < 0)
            {
                throw new ArgumentException("Speed can't be negative");
            }

            this.carInformation.CurrentSpeed = speed;
        }

        public void SendInformationToOne(Car car)
        {   

            if(car == null)
            {
                throw new ArgumentNullException();
            }

            car.ReceiveInformation(this);

        }
        
        public void SendInformationToMultipleCars(List<Car> cars)
        {
            foreach(Car car in cars)
            {
                car.ReceiveInformation(this);
            }
        }

        public void ReceiveInformation(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException();
            }

            infoOtherCars.Add(car.CarInformation);
        }

        public void ReceiveInformationFromMultipleCars(List<Car> cars)
        {
            foreach(Car car in cars)
            {
                this.ReceiveInformation(car);
            }
        }
        //Euclidian distance
        public double CalculateDistance(Car car)
        {
            return Math.Sqrt(Math.Pow((this.carInformation.Location.X - car.CarInformation.Location.X), 2) + Math.Pow((this.carInformation.Location.Y - car.CarInformation.Location.Y), 2));
        }

        public Car GetNearestCar(List<Car> cars)
        {
            Car nearestCar = null;
            double min = Int32.MaxValue;
            

            foreach(Car car in cars)
            {   
                double distance = CalculateDistance(car);
                
                if (distance < min)
                {
                    min = distance;
                    nearestCar = car;
                }

            }

            return nearestCar;
            
        }


        public void AddEvent(Event ev)
        {
            if(ev == null)
            {
                throw new ArgumentNullException();
            }

            //keep events in the last 100km
            List<Event> newList = new List<Event>();
            foreach(Event carEvent in this.carInformation.Events)
            {
                if(ev.Kilometer - carEvent.Kilometer < 100)
                {
                    newList.Add(carEvent);
                }

            }

            newList.Add(ev);
            this.carInformation.Events = newList;
        }

        public void SetNewLocation(Location location)
        {
            if (location == null)
            {
                throw new ArgumentNullException();
            }

            this.carInformation.Location = location;
        }

    }
}
