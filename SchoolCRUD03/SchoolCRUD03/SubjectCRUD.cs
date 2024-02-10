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
    public static class SubjectCRUD
    {
        public static void PrintAllSubjects()
        {
            try
            {
                List<SubjectModel> subjects = SubjectService.getAllSubjects();

                Console.WriteLine("Subject Details :");

                Console.Write("subjectId".PadRight(10) + "  " +
                                  "Subject Name".PadRight(15) + "  " +
                                  "Book".PadRight(15) + "  " +
                                  "SubjectTeacher".PadRight(20));
                Console.WriteLine();
                foreach (SubjectModel subject in subjects)
                {
                    Console.Write(subject.SubjectId.ToString().PadRight(10) + "  " +
                              subject.Name.ToString().PadRight(15) + "  " +
                              subject.Book.ToString().PadRight(15) + "  " +
                              subject.SubjectTeacher.ToString().PadRight(20));
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.WriteLog(ex.Message);
            }
        }

        public static void AddNewSubject()
        {
            try
            {
                Console.WriteLine("Enter new subject details:");

                Console.Write("Subject ID: ");
                int subjectId = int.Parse(Console.ReadLine());

                Console.Write("Subject name: ");
                string subjectName = Console.ReadLine();

                Console.Write("Book: ");
                string book = Console.ReadLine();

                Console.Write("Subject teacher: ");
                string subjectTeacher = Console.ReadLine();


                    var newSubject = new SubjectModel
                    {
                        SubjectId = subjectId,
                        Name = subjectName,
                        Book = book,
                        SubjectTeacher = subjectTeacher
                    };

                if (SubjectService.AddNewSubject(newSubject)) {
                    Console.WriteLine("Subject added successfully!");
                }
                else
                {
                    Console.WriteLine("Subject addition FAILED !");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.WriteLog(ex.Message);
            }
        }
        public static void DeleteSubject()
        {
            try
            {
                Console.WriteLine("Enter subject details to delete:");

                Console.Write("Subject ID: ");
                int subjectId = int.Parse(Console.ReadLine());

                if (SubjectService.DeleteSubject(subjectId))
                {
                    Console.WriteLine("Deleted Successfully");
                }
                else
                {
                    Console.WriteLine($"Subject with id {subjectId} does not exist");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.WriteLog(ex.Message);
            }

        }

        public static void CreateSubjectCSV()
        {
            Service.ConvertDataToCSV("Subject");
        }
        public static void CreateSubjectExcel()
        {
            Service.ConvertDataToExcel("Subject");
        }
    }
}
