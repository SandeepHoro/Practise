using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03.Utils
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            try
            {
                string logPath = ConfigurationManager.AppSettings["logPath"];
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now} | {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
