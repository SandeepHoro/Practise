//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolCRUD03.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public int ClassNo { get; set; }
        public int AdmissionYear { get; set; }
    
        public virtual Class Class { get; set; }
    }
}
