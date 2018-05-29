using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionOverInheritance
{
    public class ToyotaCorollaSports : ICar
    {
        public ToyotaCorollaSports()
        {
            this.FrontLeft = new Wheel();
            this.FrontRight = new Wheel();
            this.RearLeft = new Wheel();
            this.RearRight = new Wheel(0, 0);
            this.Steering = new FrontSteering(this.FrontLeft, this.FrontRight);
            this.Driving = new TwoWheelDrive(this.RearLeft, this.RearRight);
            this.Manufacturer = Toyota.GetInstance();
        }

        public IWheel FrontLeft { get; private set; }
        public IWheel FrontRight { get; private set; }
        public IWheel RearLeft { get; private set; }
        public IWheel RearRight { get; private set; }

        public ISteering Steering { get; private set; }
        public IDriving Driving { get; private set; }
        public IManufacturer Manufacturer { get; private set; }
    }
}
