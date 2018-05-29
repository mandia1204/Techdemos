using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTraining
{
    public class OldCart : IVehicle, ICar
    {
        string ICar.Ride()
        {
            return "Riding old cart, v1";
        }

        //public string Ride()
        //{
        //    return "Riding old cart";
        //}
        string IVehicle.Ride()
        {
            return "Riding old cart";
        }
    }
}
