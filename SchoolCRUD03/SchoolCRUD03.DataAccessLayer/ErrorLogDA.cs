using SchoolCRUD03.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03.DataAccessLayer
{
    public static class ErrorLogDA
    {
        public static string SaveErrorLogEntries(string filePath)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    // Read lines from the text file
                    var lines = File.ReadAllLines(filePath);

                    foreach (var line in lines)
                    {
                        var parts = line.Split('|');

                        // Parse Date
                        DateTime date = DateTime.Parse(parts[0]);

                        // Extract Error/Exception
                        string errorMessage = parts[1].Trim();

                        var existingEntry = context.ErrorLogs
                        .FirstOrDefault(e => e.ErrorDate == date && e.ErrorMessage == errorMessage);

                        // If not, create a new LogEntry instance and save it
                        if (existingEntry == null)
                        {
                            var errorLog = new ErrorLog
                            {
                                ErrorDate = date,
                                ErrorMessage = errorMessage
                            };

                            // Add to DbSet and save changes
                            context.ErrorLogs.Add(errorLog);
                            context.SaveChanges();
                            
                        }
                    }
                }
                return "Updated to ErrorLogTable";
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
                return (ex.Message);

            }
        }
    }
}
