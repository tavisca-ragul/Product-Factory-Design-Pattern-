namespace Bookings
{
    class CarFareMargin : IFareMargin
    {
        public float AddFareMargin(float price)
        {
            return price * (price % 10);
        }
    }
}
