namespace Bookings
{
    interface IProduct
    {
        string GetTypeOfProduct();
        string GetProductDetails();
        void Booked();
    }
}