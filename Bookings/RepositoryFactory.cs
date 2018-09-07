using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookings
{
    class RepositoryFactory
    {
        public static IRepository GetRepository(string repository)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var repositoryType = assembly.GetTypes().FirstOrDefault(t => t.Name == repository);
            FileLogger.Instance.ProcessLogMessage("Returning instance of called class");
            return (IRepository)Activator.CreateInstance(repositoryType);
        }
    }
}