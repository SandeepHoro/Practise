using SchoolCRUD03.DataAccessLayer;
using SchoolCRUD03.Model;
using SchoolCRUD03.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03.BussinessLogicLayer
{
    public class SubjectService
    {
        public static List<SubjectModel> getAllSubjects()
        {
             return SubjectDA.GetAllSubjects();
        }

        public static bool AddNewSubject(SubjectModel newSubject)
        {
            return SubjectDA.AddNewSubject(newSubject);     
        }
        public static bool DeleteSubject(int subjectId)
        {
            return SubjectDA.DeleteSubject(subjectId);
        }
    }
}
