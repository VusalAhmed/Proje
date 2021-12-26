using System;
using System.Collections.Generic;
using System.Text;

namespace Drive
{
    interface IVehicle
    {
        void Drive();
    }
    class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Driving Car");
        }
    }
    class Bicycle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Driving Bicycle");
        }
    }
    class Driving
    {
        public void Drive(IVehicle vehicle)
        {
            vehicle.Drive();

        }
    }
}
