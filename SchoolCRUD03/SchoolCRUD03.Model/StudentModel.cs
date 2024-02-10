using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCRUD03.Model
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public Nullable<int> ClassNo { get; set; }
        public Nullable<int> AdmissionYear { get; set; }

        //public virtual ClassModel Class { get; set; }
    }
}
