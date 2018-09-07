namespace Bookings
{
    class ActivityFareMargin : IFareMargin
    {
        public float AddFareMargin(float price)
        {
            return price * (price % 20);
        }
    }
}