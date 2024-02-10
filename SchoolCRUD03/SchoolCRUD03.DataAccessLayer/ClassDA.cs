using SchoolCRUD03.Model;
using SchoolCRUD03.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolCRUD03.DataAccessLayer
{
    public static class ClassDA
    {
        public static List<ClassModel> GetAllClassDetails()
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    var allClasses = context.Classes
                        .Include("Subjects")
                        .Include("Students")
                        .ToList();

                    List<ClassModel> classModels = allClasses.Select(c => new ClassModel
                    {
                        // Map properties from Class entity to ClassModel
                        ClassNo = c.ClassNo,
                        ClassTeacher = c.ClassTeacher,
                        Subjects = c.Subjects.Select(s => new SubjectModel
                        {
                            SubjectId = s.SubjectId,
                            Name = s.Name,
                            Book = s.Book,
                            SubjectTeacher = s.SubjectTeacher,
                        }).ToList(),
                        Students = c.Students.Select(s => new StudentModel
                        {
                            StudentId = s.StudentId,
                            Name = s.Name,
                            ClassNo = s.ClassNo,
                            PhoneNo = s.PhoneNo,
                            AdmissionYear = s.AdmissionYear
                        }).ToList()
                    }).ToList();

                    return classModels;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
                throw;
            }
        }


        public static string AddSubjectToClass(int classNo, int subjectId)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    
                    var classToAddSubjectTo = context.Classes
                                               .Include("Subjects")
                                               .SingleOrDefault(c => c.ClassNo == classNo);

                    if (classToAddSubjectTo != null)
                    {
                        // Check if the subject already exists for the class
                        var existingSubject = context.Subjects.Find(subjectId);

                        if (existingSubject != null)
                        {
                            // Check if the subject is not already associated with the class
                            if (!classToAddSubjectTo.Subjects.Any(s => s.SubjectId == subjectId))
                            {
                                // Add the subject to the class
                                classToAddSubjectTo.Subjects.Add(existingSubject);

                                context.SaveChanges();

                                return "";
                            }

                            else
                            {
                                return "Class already contains the Subject";
                            }
                        }
                        else
                        {
                            return "Subject does not exist";
                        }
                    }
                    else
                    {
                        return "Class does not exist";
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
                return ex.Message;
            }

        }

        public static string ChangeClassTeacher(int classNo, string newTeacher)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    var classToUpdate = context.Classes.FirstOrDefault(c => c.ClassNo == classNo);

                    if (classToUpdate != null)
                    {
                        classToUpdate.ClassTeacher = newTeacher;
                        context.SaveChanges();
                        return "";
                    }
                    else
                    {
                        return "Invalid ClassNo";
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.WriteLog(ex.Message);
                return "Something is wrong";
            }
        }
    }
}
