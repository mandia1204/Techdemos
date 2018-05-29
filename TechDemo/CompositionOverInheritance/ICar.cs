using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionOverInheritance
{
    public interface ICar
    {
        IWheel FrontLeft { get; }
        IWheel FrontRight { get; }
        IWheel RearLeft { get; }
        IWheel RearRight { get; }

        ISteering Steering { get; }
        IDriving Driving { get; }
        IManufacturer Manufacturer { get; }
    }
}
