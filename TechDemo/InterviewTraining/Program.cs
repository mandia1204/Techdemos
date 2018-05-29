using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = Cart.GetCart();
            var cart2 = (new Cart()).GetCartNoStatic();

            var vehicles = new List<IVehicle>
            {
                new Cart(),
                new OldCart()
            };

            vehicles.ForEach(v => Console.WriteLine(v.Ride()));

            Console.ReadLine();
        }
    }
}
