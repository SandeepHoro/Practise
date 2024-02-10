using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03.Model
{
    public class ClassModel
    {
        public int ClassNo { get; set; }
        public string ClassTeacher { get; set; }

        public virtual ICollection<StudentModel> Students { get; set; }
        public virtual ICollection<SubjectModel> Subjects { get; set; }
    }
}
