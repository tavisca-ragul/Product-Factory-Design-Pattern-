using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookings
{
    class ProductFactory
    {
        public static IProduct GetProduct(string product)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var productType = assembly.GetTypes().FirstOrDefault(t => t.Name == product);
            FileLogger.Instance.ProcessLogMessage("Returning instance of called class");
            return (IProduct)Activator.CreateInstance(productType);
        }
    }
}