using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionOverInheritance
{
    public interface IWheel
    {
        double RotationSpeed { get; set; }
        double Angle { get; set; }
    }
}
