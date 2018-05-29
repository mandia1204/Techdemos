using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionOverInheritance
{
    public class Wheel : IWheel
    {
        public double Angle
        {
            get; set;
        }

        public double RotationSpeed
        {
            get; set;
        }

        public Wheel() { }

        public Wheel(double angle, double rotationSpeed)
        {
            this.Angle = angle;
            this.RotationSpeed = rotationSpeed;
        }
    }
}
