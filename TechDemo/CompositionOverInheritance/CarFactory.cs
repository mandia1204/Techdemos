using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionOverInheritance
{
    public static class CarFactory
    {
        public static ICar ToyotaCorolla()
        {
            IWheel frontLeft = new Wheel();
            IWheel frontRight = new Wheel();
            return new Car(frontLeft, frontRight, new Wheel(), new Wheel(),
              new FrontSteering(frontLeft, frontRight),
              new TwoWheelDrive(frontLeft, frontRight), Toyota.GetInstance(),
              "Corolla");
        }
        public static ICar ToyotaCorollaSports()
        {
            IWheel frontLeft = new Wheel();
            IWheel frontRight = new Wheel();
            IWheel rearLeft = new Wheel();
            IWheel rearRight = new Wheel();
            return new Car(frontLeft, frontRight, rearLeft, rearRight,
              new FrontSteering(frontLeft, frontRight),
              new TwoWheelDrive(rearLeft, rearRight), Toyota.GetInstance(),
              "Corolla Sports");
        }
    }
}
