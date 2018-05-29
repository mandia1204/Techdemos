using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionOverInheritance
{
    public class FrontSteering : ISteering
    {
        private readonly IWheel frontLeft;
        private readonly IWheel frontRight;

        public FrontSteering(IWheel frontLeft, IWheel frontRight)
        {
            this.frontLeft = frontLeft;
            this.frontRight = frontRight;
        }

        public void TurnLeft(double degrees)
        {
            this.frontLeft.Angle -= degrees;
            this.frontRight.Angle -= degrees;
        }

        public void TurnRight(double degrees)
        {
            this.frontLeft.Angle += degrees;
            this.frontRight.Angle += degrees;
        }
    }
}
