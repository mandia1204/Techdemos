using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionOverInheritance
{
    public class Toyota : IManufacturer
    {
        private static IManufacturer instance;

        private Toyota() { }

        public string Name { get { return "Toyota"; } }

        public static IManufacturer GetInstance()
        {
            return instance ?? (instance = new Toyota());
        }
    }
}
