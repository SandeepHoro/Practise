using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03.Model
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Book { get; set; }
        public string SubjectTeacher { get; set; }
        public virtual ICollection<ClassModel> Classes { get; set; }
    }
}
