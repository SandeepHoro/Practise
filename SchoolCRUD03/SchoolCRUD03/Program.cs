using SchoolCRUD03.BussinessLogicLayer;
using SchoolCRUD03.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("\n---------------");
                Console.WriteLine($"{(int)Operation.PrintAllStudents}. Show all Student details");
                Console.WriteLine($"{(int)Operation.AddNewStudent}. Add new student");
                Console.WriteLine($"{(int)Operation.DeleteStudent}. Delete/Remove student");
                Console.WriteLine();
                Console.WriteLine($"{(int)Operation.PrintAllSubjects}. Show all Subject detail");
                Console.WriteLine($"{(int)Operation.AddNewSubject}. Add new subject");
                Console.WriteLine($"{(int)Operation.DeleteSubject}. Delete/Remove subject");
                Console.WriteLine();
                Console.WriteLine($"{(int)Operation.ShowllClassDetails}. Show all class details");
                Console.WriteLine($"{(int)Operation.AddSubjectToClass}. Add subject to class");
                Console.WriteLine($"{(int)Operation.ChangeClassTeacher}. Change Class Teacher");
                Console.WriteLine();
                Console.WriteLine($"{(int)Operation.CreateStudentCSV}. Create Student CSV file");
                Console.WriteLine($"{(int)Operation.CreateStudentExcel}. Create Student Excel file");
                Console.WriteLine();
                Console.WriteLine($"{(int)Operation.CreateClassCSV}. Create Class CSV file");
                Console.WriteLine($"{(int)Operation.CreateClassExcel}. Create Class Excel file");
                Console.WriteLine();
                Console.WriteLine($"{(int)Operation.CreateSubjectCSV}. Create Subject CSV file");
                Console.WriteLine($"{(int)Operation.CreateSubjectExcel}. Create Subject Excel file");
                Console.WriteLine();
                Console.WriteLine($"{(int)Operation.SaveErrorLogEntries}. Save Error Log Table");
                Console.WriteLine($"{(int)Operation.EXIT}. EXIT");
                Console.WriteLine();
                Console.Write("Select one option : ");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("---------------");
                    Operation inputOperation = (Operation)(option);

                    switch (inputOperation)
                    {
                        case Operation.PrintAllStudents: StudentCRUD.PrintAllStudents(); break;
                        case Operation.AddNewStudent: StudentCRUD.AddNewStudent(); break;
                        case Operation.DeleteStudent: StudentCRUD.DeleteStudent(); break;
                        case Operation.PrintAllSubjects: SubjectCRUD.PrintAllSubjects(); break;
                        case Operation.AddNewSubject: SubjectCRUD.AddNewSubject(); break;
                        case Operation.DeleteSubject: SubjectCRUD.DeleteSubject(); break;
                        case Operation.ShowllClassDetails: ClassCRUD.ShowllClassDetails(); break;
                        case Operation.AddSubjectToClass: ClassCRUD.AddSubjectToClass(); break;
                        case Operation.ChangeClassTeacher: ClassCRUD.ChangeClassTeacher(); break;
                        case Operation.CreateStudentCSV: StudentCRUD.CreateStudentCSV(); break;
                        case Operation.CreateStudentExcel: StudentCRUD.CreateStudentExcel(); break;
                        case Operation.CreateClassCSV: ClassCRUD.CreateClassCSV(); break;
                        case Operation.CreateClassExcel: ClassCRUD.CreateClassExcel(); break;
                        case Operation.CreateSubjectCSV: SubjectCRUD.CreateSubjectCSV(); break;
                        case Operation.CreateSubjectExcel: SubjectCRUD.CreateSubjectExcel(); break;
                        case Operation.SaveErrorLogEntries: Console.WriteLine(Service.SaveErrorLogEntries()); break;
                        case Operation.EXIT: Console.WriteLine("Thank You"); break;

                        default: Console.WriteLine("Invalid option."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Logger.WriteLog(ex.Message);
                }

            } while (option != (int)Operation.EXIT);

            Console.WriteLine("Exiting");
            Console.ReadLine();
        }


        public enum Operation
        {
            PrintAllStudents=1,
            AddNewStudent,
            DeleteStudent,
            PrintAllSubjects,
            AddNewSubject,
            DeleteSubject,
            ShowllClassDetails,
            AddSubjectToClass,
            ChangeClassTeacher,
            CreateStudentCSV,
            CreateStudentExcel,
            CreateClassCSV,
            CreateClassExcel,
            CreateSubjectCSV,
            CreateSubjectExcel,
            SaveErrorLogEntries,
            EXIT
        }
    }

}

