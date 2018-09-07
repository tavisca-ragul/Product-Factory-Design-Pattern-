using System;
using System.IO;

namespace Bookings
{
    class FileDatabase : IRepository
    {
        private static FileStream _Connection;
        private static StreamWriter _Execute;
        public void CreateConnection()
        {
            _Connection = new FileStream("C:\\Users\\rkrishnan\\Desktop\\Bookings\\Bookings\\savefile.txt", FileMode.Append, FileAccess.Write);
            _Execute = new StreamWriter(_Connection);
            FileLogger.Instance.ProcessLogMessage("FileDatabase connection is created");
        }

        public bool BookProducts(IProduct product)
        {
            string productType = product.GetTypeOfProduct();
            string[] productMembers = product.GetProductDetails().Split(',');
            int id = int.Parse(productMembers[0]);
            string name = productMembers[1];
            float price = float.Parse(productMembers[2]);
            bool isBooked = bool.Parse(productMembers[3]);
            try
            {
                if (isBooked)
                    throw new Exception();
                _Execute.WriteLine(string.Format("{0} ID: {1}", productType, id));
                _Execute.WriteLine(string.Format("{0} Company Name: {1}", productType, name));
                _Execute.WriteLine(string.Format("{0} Price: {1}", productType, price));
                _Execute.Close();
                FileLogger.Instance.ProcessLogMessage(string.Format("{0} is booked", productType));
                product.Booked();
                Console.WriteLine(string.Format("{0} is booked", productType));
                return true;
            }
            catch(Exception exception)
            {
                Console.WriteLine("Already Booked");
                FileLogger.Instance.ProcessLogMessage(string.Format("{0} booking is cancelled", productType));
                return false;
            }
        }

        public bool SaveProducts(IProduct product)
        {
            string productType = product.GetTypeOfProduct();
            string[] productMembers = product.GetProductDetails().Split(',');
            int id = int.Parse(productMembers[0]);
            string name = productMembers[1];
            float price = float.Parse(productMembers[2]);
            bool isBooked = bool.Parse(productMembers[3]);
            try
            {
                _Execute.WriteLine("---------------Saving-----------------");
                _Execute.WriteLine(string.Format("{0} ID: {1}", productType, id));
                _Execute.WriteLine(string.Format("{0} Company Name: {1}", productType, name));
                _Execute.WriteLine(string.Format("{0} Price: {1}", productType, price));
                FileLogger.Instance.ProcessLogMessage(string.Format("{0} is Saved", productType));
                Console.WriteLine(string.Format("{0} is Saved", productType));
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Saving is cancelled");
                FileLogger.Instance.ProcessLogMessage(string.Format("{0} saving is cancelled", productType));
                return false;
            }
        }
    }
}