using System;

namespace Bookings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Available Products: 1.CarProduct 2.AirProduct 3.HotelProduct 4.ActivityProduct\nEnter the product:");
            string productType = Console.ReadLine();
            FileLogger.Instance.ProcessLogMessage(String.Format("Getting {0} product instance", productType));
            IProduct product = ProductFactory.GetProduct(productType);
            Console.WriteLine("Available Products: 1.FileDatabase 2.SQLDatabse\nEnter the product:");
            string repositoryType = Console.ReadLine();
            IRepository repository = RepositoryFactory.GetRepository(repositoryType);
            FileLogger.Instance.ProcessLogMessage(string.Format("{0} instance is created", repositoryType));
            repository.CreateConnection();
            FileLogger.Instance.ProcessLogMessage(string.Format("{0} connection is created", repositoryType));
            repository.SaveProducts(product);
            repository.BookProducts(product);
            FileLogger.Instance.CloseLogfile();
            Console.ReadLine();
        }
    }
}