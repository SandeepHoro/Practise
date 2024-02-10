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
    public static  class SubjectDA
    {
        public static List<SubjectModel> GetAllSubjects()
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    return context.Subjects.Select(s => new SubjectModel
                    {
                        SubjectId = s.SubjectId,
                        Name = s.Name,
                        Book = s.Book,
                        SubjectTeacher = s.SubjectTeacher,
                    }).ToList();
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
                throw;

            }
        }

        public static bool AddNewSubject(SubjectModel newSubject)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    var subject = new Subject
                    {
                        SubjectId = newSubject.SubjectId,
                        Name = newSubject.Name,
                        Book = newSubject.Book,
                        SubjectTeacher = newSubject.SubjectTeacher,
                    };
                    context.Subjects.Add(subject);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
                return false;
            }

        }
        public static bool DeleteSubject(int subjectId)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    var subjectToDelete = context.Subjects.Find(subjectId);

                    if (subjectToDelete != null)
                    {
                        context.Subjects.Remove(subjectToDelete);
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
