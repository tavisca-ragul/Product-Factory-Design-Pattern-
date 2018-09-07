namespace Bookings
{
    interface IRepository
    {
        void CreateConnection();
        bool BookProducts(IProduct product);
        bool SaveProducts(IProduct product);
    }
}