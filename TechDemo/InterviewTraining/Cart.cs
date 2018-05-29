using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTraining
{
    public class Cart: IVehicle, ICar
    {
        public static string GetCart()
        {
            return "This is the cart";
        }

        public string GetCartNoStatic()
        {
            return "This is the cart nostatic";
        }

        string IVehicle.Ride()
        {
            return "Riding cart";
        }

        string ICar.Ride()
        {
            return "Riding cart, v1";
        }

        //public string Ride()
        //{
        //    return "Riding cart";
        //}
    }
}
