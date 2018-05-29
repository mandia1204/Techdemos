using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionOverInheritance
{
    public class TwoWheelDrive : IDriving
    {
        private readonly IWheel left;
        private readonly IWheel right;

        public TwoWheelDrive(IWheel left, IWheel right)
        {
            this.left = left;
            this.right = right;
        }

        public void Accelerate(double kph)
        {
            this.left.RotationSpeed += kph;
            this.right.RotationSpeed += kph;
        }
    }
}
