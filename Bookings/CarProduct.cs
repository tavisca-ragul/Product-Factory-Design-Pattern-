using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings
{
    class CarProduct : IProduct
    {
        public CarProduct()
        {
            ID = 1;
            Name = "Audi";
            Price = 4500;
            isBooked = false;
        }

        public int ID { get; }
        public string Name { get; }
        public float Price { get; }
        public bool isBooked { get; set; }

        public string GetTypeOfProduct()
        {
            return "CarProduct";
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