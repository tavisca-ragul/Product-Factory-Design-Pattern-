using System;
using System.Data;
using System.Data.SqlClient;

namespace Bookings
{
    class SQLDatabase : IRepository
    {
        SqlConnectionStringBuilder Builder;
        SqlConnection Connection;
        SqlCommand Statement;
        String Query;

        public void CreateConnection()
        {
            Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = "localhost";
            Builder.UserID = "sa";
            Builder.Password = "test123!@#";
            Builder.InitialCatalog = "Product";
            Connection = new SqlConnection(Builder.ConnectionString);
            Query = null;
            Statement = null;
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
                Query = "insert into " + productType + "(id, name, price, is_booked) values(@Id, @Name, @Price, @IsBooked)";
                Connection.Open();
                Statement = new SqlCommand(Query, Connection);
                Statement.CommandType = CommandType.Text;
                Statement.Parameters.AddWithValue("@Id", id);
                Statement.Parameters.AddWithValue("@Name", name);
                Statement.Parameters.AddWithValue("@Price", price);
                Statement.Parameters.AddWithValue("@IsBooked", false);
                Statement.ExecuteNonQuery();
                Connection.Close();
                Console.WriteLine(string.Format("{0} is Saved", productType));
                FileLogger.Instance.ProcessLogMessage(string.Format("{0} is Saved", productType));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("{0} is not Saved", productType));
                FileLogger.Instance.ProcessLogMessage(string.Format("{0} Saving is cancelled", productType));
                return false;
            }
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
                Query = "update "+ productType + " set is_booked=@IsBooked where id=@ID";
                Connection.Open();
                Statement = new SqlCommand(Query, Connection);
                Statement.CommandType = CommandType.Text;
                Statement.Parameters.AddWithValue("@Id", id);
                Statement.Parameters.AddWithValue("@IsBooked", true);
                Statement.ExecuteNonQuery();
                Connection.Close();
                product.Booked();
                Console.WriteLine(string.Format("{0} is Booked", productType));
                FileLogger.Instance.ProcessLogMessage(string.Format("{0} is Booked", productType));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("{0} is already Booked", productType));
                Console.WriteLine(ex.Message);
                FileLogger.Instance.ProcessLogMessage(string.Format("{0} Booking is cancelled", productType));
                return false;
            }
        }
    }
}