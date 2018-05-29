using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionOverInheritance
{
    public class Program
    {
        public static int find(int one, int two, int three)
        {
            return (one > two) ? (one > three ? one : three) : (two > three ? two : three);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(find(-1, -2, -3));
        }
    }
}
