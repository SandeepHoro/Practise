using SchoolCRUD03.BussinessLogicLayer;
using SchoolCRUD03.Model;
using SchoolCRUD03.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03
{
    public static class StudentCRUD
    {
        public static void PrintAllStudents()
        {
            try
            {
                List<StudentModel> students = StudentService.GetAllStudents();

                Console.WriteLine("Student Details :");

                Console.Write("studentId".PadRight(10) + "  " +
                                  "name".PadRight(15) + "  " +
                                  "classNo".PadRight(7) + "  " +
                                  "phone_no".PadRight(12) + "  " +
                                  "admission year".PadRight(7));
                Console.WriteLine();
                foreach (StudentModel student in students)
                {
                    Console.Write(student.StudentId.ToString().PadRight(10) + "  " +
                                  student.Name.ToString().PadRight(15) + "  " +
                                  student.ClassNo.ToString().PadRight(7) + "  " +
                                  student.PhoneNo.ToString().PadRight(12) + "  " +
                                  student.AdmissionYear.ToString().PadRight(7));
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.WriteLog(ex.Message);
            }
        }

        public static void AddNewStudent()
        {
            try
            {
                Console.Write("Student ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Class number: ");
                int classNo = int.Parse(Console.ReadLine());

                Console.Write("Phone number: ");
                string phoneNo = Console.ReadLine();

                Console.Write("Admission year: ");
                int admissionYear = int.Parse(Console.ReadLine());

                if(StudentService.AddNewStudent(id, name, classNo, phoneNo, admissionYear))
                {
                    Console.WriteLine("Student added successfully!");
                }
                else
                {
                    Console.WriteLine("Student addition failed !");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.WriteLog(ex.Message);
            }

        }
        public static void DeleteStudent()
        {
            try
            {
                Console.Write("Enter student id : ");
                int studentId = int.Parse(Console.ReadLine());
                if (StudentService.DeleteStudent(studentId)){
                    Console.WriteLine("Deleted Successfully");
                }
                else
                {
                    Console.WriteLine($"Student with id {studentId} does not exist");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.WriteLog(ex.Message);
            }
        }
        public static void CreateStudentCSV()
        {
            Service.ConvertDataToCSV("Student");
        }
        public static void CreateStudentExcel()
        {
            Service.ConvertDataToExcel("Student");
        }
    }
}
