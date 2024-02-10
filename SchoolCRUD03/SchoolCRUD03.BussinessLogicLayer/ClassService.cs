using SchoolCRUD03.DataAccessLayer;
using SchoolCRUD03.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03.BussinessLogicLayer
{
    public static class ClassService
    {
        public static List<ClassModel> GetAllClassDetails()
        {
            return ClassDA.GetAllClassDetails();
        }

        public static string AddSubjectToClass(int classNo, int subjectId)
        {
            return ClassDA.AddSubjectToClass(classNo, subjectId);
        }
        public static string ChangeClassTeacher(int classNo, string newTeacher)
        {
            return ClassDA.ChangeClassTeacher(classNo, newTeacher);
        }
    }
}
