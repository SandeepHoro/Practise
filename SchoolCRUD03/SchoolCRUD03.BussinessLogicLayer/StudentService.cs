using SchoolCRUD03.DataAccessLayer;
using SchoolCRUD03.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03.BussinessLogicLayer
{
    public static class StudentService
    {
        public static List<StudentModel> GetAllStudents()
        {
            return StudentDA.GetAllStudents();
        }

        public static bool AddNewStudent(int id, string name, int classNo, string phoneNo, int admissionYear)
        {
            return StudentDA.AddNewStudent(id,name,classNo, phoneNo, admissionYear);
        }
     
        public static bool DeleteStudent(int studentId)
        {
            return StudentDA.DeleteStudent(studentId);
        }
    }
}
