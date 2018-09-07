namespace Bookings
{
    class AirFareMargin : IFareMargin
    {
        public float AddFareMargin(float price)
        {
            return price * (price % 40);
        }
    }
}
