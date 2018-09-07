using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings
{
    class AirProduct : IProduct
    {
        public AirProduct()
        {
            ID = 1;
            Name = "Indigo";
            Price = 8500;
            isBooked = false;
        }

        public int ID { get; }
        public string Name { get; }
        public float Price { get; }
        public static bool isBooked { get; set; }

        public string GetTypeOfProduct()
        {
            return "AirProduct";
        }

        public string GetProductDetails()
        {
            return string.Format("{0},{1},{2},{3}", ID, Name, Price, isBooked);
        }

        public void Booked()
        {
            isBooked = true;
        }
    }
}