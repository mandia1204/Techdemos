using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionOverInheritance
{
    public class Car : ICar
    {
        public Car(IWheel frontLeft, IWheel frontRight, IWheel rearLeft,
                  IWheel rearRight, ISteering steering, IDriving driving,
                  IManufacturer manufacturer, string carName)
        {
            this.FrontLeft = frontLeft;
            this.FrontRight = frontRight;
            this.RearLeft = rearLeft;
            this.RearRight = rearRight;
            this.Steering = steering;
            this.Driving = driving;
            this.Manufacturer = manufacturer;
            this.Name = carName;
        }

        public IWheel FrontLeft { get; private set; }
        public IWheel FrontRight { get; private set; }
        public IWheel RearLeft { get; private set; }
        public IWheel RearRight { get; private set; }

        public ISteering Steering { get; private set; }
        public IDriving Driving { get; private set; }
        public IManufacturer Manufacturer { get; private set; }
        public string Name { get; private set; }
    }
}
