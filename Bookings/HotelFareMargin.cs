namespace Bookings
{
    class HotelFareMargin : IFareMargin
    {
        public float AddFareMargin(float price)
        {
            return price * (price % 30);
        }
    }
}