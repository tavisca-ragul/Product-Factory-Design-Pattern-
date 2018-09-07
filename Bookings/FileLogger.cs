using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings
{
    class FileLogger : ILogger
    {
        private static FileLogger _Instance = null;
        private static FileStream _FileStream;
        private static StreamWriter _FileWriter;
        public static FileLogger Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new FileLogger();
                return _Instance;
            }
        }

        private FileLogger()
        {
            _FileStream = new FileStream("C:\\Users\\rkrishnan\\Desktop\\Bookings\\Bookings\\logfile.txt", FileMode.Append, FileAccess.Write);
            _FileWriter = new StreamWriter(_FileStream);
        }

        public void ProcessLogMessage(string logMessage)
        {
            _FileWriter.WriteLineAsync(logMessage);
        }

        public void CloseLogfile()
        {
            _FileWriter.Close();
        }
    }
}