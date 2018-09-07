using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings
{
    class HotelProduct : IProduct
    {
        public HotelProduct()
        {
            ID = 1;
            Name = "Nala";
            Price = 6000;
            isBooked = false;
        }

        public int ID { get; }
        public string Name { get; }
        public float Price { get; }
        public bool isBooked { get; set; }

        public string GetTypeOfProduct()
        {
            return "HotelProduct";
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