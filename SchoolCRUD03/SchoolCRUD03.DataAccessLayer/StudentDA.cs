using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using SchoolCRUD03.Model;
using SchoolCRUD03.Utils;

namespace SchoolCRUD03.DataAccessLayer
{
    public static class StudentDA
    {
        public static List<StudentModel> GetAllStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            
            try
            {
                using (var context = new SchoolEntities())
                {
                    

                    return context.Students.Select(s => new StudentModel
                    {
                         StudentId = s.StudentId,
                         Name = s.Name,
                         ClassNo = s.ClassNo,
                         PhoneNo = s.PhoneNo,
                         AdmissionYear = s.AdmissionYear
                    }).ToList();
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
                throw;
            }
        }

        public static bool AddNewStudent(int id, string name, int classNo, string phoneNo, int admissionYear)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    var newStudent = new Student
                    {
                        StudentId = id,
                        Name = name,
                        ClassNo = classNo,
                        PhoneNo = phoneNo,
                        AdmissionYear = admissionYear
                    };
                    context.Students.Add(newStudent);
                    context.SaveChanges();
                }

                return true;
            }
            catch(Exception ex) 
            { 
                Logger.WriteLog(ex.Message);
                return false;
            }
            

        }
        public static bool DeleteStudent(int studentId)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    var studentToDelete = context.Students.Find(studentId);

                    if (studentToDelete != null)
                    {
                        context.Students.Remove(studentToDelete);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
                throw;
            }
        }
    }
}
