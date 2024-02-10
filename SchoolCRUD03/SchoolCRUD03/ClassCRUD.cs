using SchoolCRUD03.BussinessLogicLayer;
using SchoolCRUD03.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03
{
    public class ClassCRUD
    {
        public static void ShowllClassDetails()
        {
            try
            {
                var allClasses = ClassService.GetAllClassDetails();

                Console.Write("class".PadRight(10) + " " +
                                        "classTeacher".PadRight(15) + " " +
                                        "totalStudents".PadRight(15) + " " +
                                        "Subjects".PadRight(15)
                                        );
                Console.WriteLine();

                foreach (var classItem in allClasses)
                {
                    Console.Write(classItem.ClassNo.ToString().PadRight(10) + " " + classItem.ClassTeacher.ToString().PadRight(15) + " ");
                    int studentCount = classItem.Students.Count;
                    Console.Write(studentCount.ToString().PadRight(15));

                    foreach (var subject in classItem.Subjects)
                    {
                        Console.Write(subject.Name + ", ");
                    }

                    Console.WriteLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.WriteLog(ex.Message);
            }

        }

        public static void AddSubjectToClass()
        {
            try
            {

                Console.Write("Class No: ");
                int classNo = int.Parse(Console.ReadLine());

                Console.Write("Subject Id :");
                int subjectId = int.Parse(Console.ReadLine());

                string msg = ClassService.AddSubjectToClass(classNo, subjectId);
                if (msg == "")
                {
                    Console.WriteLine("Subjec added to class");
                }
                else
                {
                    Console.WriteLine(msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.WriteLog(ex.Message);
            }
        }
        public static void ChangeClassTeacher()
        {
            try
            {
                Console.Write("Enter ClassNo : ");
                int classNo = int.Parse(Console.ReadLine());

                Console.Write("Enter Teacher Name : ");
                string newTeacher = Console.ReadLine();

                string message = ClassService.ChangeClassTeacher(classNo,newTeacher);
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void CreateClassCSV()
        {
            Service.ConvertDataToCSV("Class");
        }
        public static void CreateClassExcel()
        {
            Service.ConvertDataToExcel("Class");
        }
    }
}
