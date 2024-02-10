using SchoolCRUD03.DataAccessLayer;
using SchoolCRUD03.Model;
using SchoolCRUD03.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using OfficeOpenXml;

using System.Threading.Tasks;

namespace SchoolCRUD03.BussinessLogicLayer
{
    public static class Service
    {
        public static void ConvertDataToCSV(string tableName)
        {
            try
            {
                List<object> data = new List<object>();
                var properties = new PropertyInfo[] { };
                string outputPath = "";
                
                if (tableName == "Student")
                {
                    data = new List<object>(StudentDA.GetAllStudents());
                    properties = typeof(StudentModel).GetProperties();
                    outputPath = ConfigurationManager.AppSettings["studentCSVpath"];
                }
                else if (tableName == "Class")
                {
                    data = new List<object>(ClassDA.GetAllClassDetails());
                    properties = typeof(ClassModel).GetProperties();
                    outputPath = ConfigurationManager.AppSettings["classCSVpath"];
                }
                else if(tableName == "Subject")
                {
                    data = new List<object>(SubjectDA.GetAllSubjects());
                    properties = typeof(SubjectModel).GetProperties();
                    outputPath = ConfigurationManager.AppSettings["subjectCSVpath"];
                }
                Console.WriteLine(outputPath);

                if (data.Any())
                {

                    StringBuilder csvContent = new StringBuilder();

                    csvContent.AppendLine(string.Join(",", properties.Select(p => p.Name)));

                    // Write data to CSV
                    foreach (var row in data)
                    {
                        var rowValues = properties.Select(p => p.GetValue(row, null));
                        csvContent.AppendLine(string.Join(",", rowValues));
                    }

                    // Write CSV content to file
                    File.WriteAllText(outputPath, csvContent.ToString());

                    Console.WriteLine($"'{tableName}'CSV file  created successfully.");
                }
                else
                {
                    Console.WriteLine("No data to export.");
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
            }
        }

        public static void ConvertDataToExcel(string tableName)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    List<object> data = new List<object>();
                    var properties = new PropertyInfo[] { };
                    string outputPath = "";
                    Console.WriteLine(outputPath);
                    if (tableName == "Student")
                    {
                        data = new List<object>(StudentDA.GetAllStudents());
                        properties = typeof(StudentModel).GetProperties();
                        outputPath = ConfigurationManager.AppSettings["studentExcelPath"];
                        
                    }
                    else if (tableName == "Class")
                    {
                        data = new List<object>(ClassDA.GetAllClassDetails());
                        properties = typeof(ClassModel).GetProperties();
                        outputPath = ConfigurationManager.AppSettings["classExcelPath"];

                    }
                    else if (tableName == "Subject")
                    {
                        data = new List<object>(SubjectDA.GetAllSubjects());
                        properties = typeof(SubjectModel).GetProperties();
                        outputPath = ConfigurationManager.AppSettings["subjectExcelPath"];
                    }

                    // Write header (column names) to Excel
                    for (int col = 1; col <= properties.Length; col++)
                    {
                        worksheet.Cells[1, col].Value = properties[col - 1].Name;
                    }

                    // Write data to Excel
                    int row = 2;
                    foreach (var item in data)
                    {
                        for (int col = 1; col <= properties.Length; col++)
                        {
                            worksheet.Cells[row, col].Value = properties[col - 1].GetValue(item);
                        }
                        row++;
                    }

                    // Save the Excel package to a file
                    File.WriteAllBytes(outputPath, package.GetAsByteArray());

                    Console.WriteLine($" '{tableName}'Excel file  created successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static string SaveErrorLogEntries()
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            return ErrorLogDA.SaveErrorLogEntries(logPath);
        }

        /*
        static void ConvertTableToClassExcel(string tableName, string outputPath)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    var data = ClassDA.GetAllClassDetails();

                    // Get flattened properties
                    var properties = GetFlattenedProperties(data.First());
                    for (int col = 1; col <= properties.Length; col++)
                    {
                        worksheet.Cells[1, col].Value = properties[col - 1];
                    }

                    // Write data to Excel
                    int row = 2;
                    foreach (var item in data)
                    {
                        var flattenedData = FlattenObject(item);
                        for (int col = 1; col <= flattenedData.Length; col++)
                        {
                            worksheet.Cells[row, col].Value = flattenedData[col - 1];
                        }
                        row++;
                    }

                    // Save the Excel package to a file
                    File.WriteAllBytes(outputPath, package.GetAsByteArray());

                    Console.WriteLine($"Excel file created successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Logger.WriteLog(ex.Message);
            }
        }

        static string[] GetFlattenedProperties(object obj)
        {
            var propertiesList = new List<string>();
            FlattenProperties(obj, "", propertiesList);
            return propertiesList.ToArray();
        }

        static string[] FlattenObject(object obj)
        {
            var flattenedData = new List<string>();
            FlattenProperties(obj, "", flattenedData);
            return flattenedData.ToArray();
        }

        static void FlattenProperties(object obj, string prefix, List<string> properties)
        {
            var objType = obj.GetType();
            var nestedProperties = objType.GetProperties()
                .Where(prop => prop.PropertyType.IsClass && prop.PropertyType != typeof(string));

            foreach (var property in objType.GetProperties())
            {
                var fullName = string.IsNullOrEmpty(prefix) ? property.Name : $"{prefix}.{property.Name}";
                var propertyValue = property.GetValue(obj);

                properties.Add(propertyValue != null ? propertyValue.ToString() : null);

                if (nestedProperties.Any(np => np.Name == property.Name))
                {
                    var nestedObj = propertyValue;
                    FlattenProperties(nestedObj, fullName, properties);
                }
            }
        }
        */



    }
}
